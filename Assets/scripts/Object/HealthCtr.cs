using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;

public class HealthCtr : MonoBehaviour {

    private ReactiveProperty<int> rxShield = null;
    private ReactiveProperty<int> rxHp = null;
    private int MaxHP = 0;
    private bool isDie = false;
    //Actor가 여기에 상태를 주고 값을 변경해줘야한다.
    //이친구가 다른 사람에게 감소에 대한 수치를 보내줘야 한다.

    public enum HealthStatus
    {
        Poison,
        Fire,
    }

    private Dictionary<HealthStatus, GameObject> healthStat;


    private List<ReactiveProperty<int>> Instanceshields = null;
    public void InitHealth(ReactiveProperty<int> shield,ReactiveProperty<int> hp,int MaxHP)
    {
        healthStat = new Dictionary<HealthStatus, GameObject>();
        Instanceshields = new List<ReactiveProperty<int>>();
        rxShield = shield;
        rxHp = hp;
        this.MaxHP = MaxHP;
    }

    #region Effect

    public GameObject GetHealthStat(HealthStatus stat)
    {
        if (healthStat.ContainsKey(stat))
        {
            return healthStat[stat];
        }
        return null;
    }

    public void SetStat(HealthStatus stat, GameObject obj)
    {
        healthStat[stat] = obj;
    }

    public void ClearStat(HealthStatus stat)
    {
        healthStat[stat] = null;
    }


    #endregion

    #region InstanceShield

    public void AddInstanceShield(ReactiveProperty<int> shield)
    {
        Instanceshields.Add(shield);
        shield.DistinctUntilChanged().Where(x => x <= 0)
            .Subscribe(_ =>
            {
                Instanceshields.Remove(shield);
                Debug.Log("Current Count " + Instanceshields.Count);
            });
    }

    #endregion

    #region Shield
    public int GetShield()
    {
        return rxShield.Value;
    }

    public void AddShield(int shield)
    {
        rxShield.Value = rxShield.Value + shield;
    }

    public int DamageShield(int value)
    {


        int shield = rxShield.Value;
        int realValue = shield - value;
        rxShield.Value = Mathf.Max(0, realValue);
        return realValue;
    }


    #endregion


    #region HP

    public int GetHP()
    {
        return rxHp.Value;
    }

    public void CureHP(int value)
    {
        int hp = rxHp.Value;
        rxHp.Value = Mathf.Min(MaxHP, hp + value);
    }

    public int DamageHP(int value)
    {
        int hp = rxHp.Value;
        int realValue = hp - value;
        rxHp.Value = Mathf.Max(0, realValue);
        if (realValue <= 0)
        {
            isDie = true;
        }
        return realValue;
    }

    #endregion


    public delegate void CustomDamageFunc(ReactiveProperty<int> hp, ReactiveProperty<int> shield, int MaxHP);
    public void CustomDamage(CustomDamageFunc func)
    {
        func(rxHp,rxShield,MaxHP);
    }

}
