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


    public void InitHealth(ReactiveProperty<int> shield,ReactiveProperty<int> hp,int MaxHP)
    {
        rxShield = shield;
        rxHp = hp;
        this.MaxHP = MaxHP;
    }


    public void AddShield(int shield)
    {
        rxShield.Value = Mathf.Max(0, rxShield.Value + shield);
    }

    public void RestoreHP(int restore)
    {
        rxHp.Value = Mathf.Min(rxHp.Value + restore, MaxHP);
    }


    public void Damaged(int damage)
    {
        int shield = rxShield.Value;
        int hp = rxHp.Value;
        //보호막이 있다면 보막부터
        int remainDamage = damage;
        if (shield > 0)
        {
            remainDamage = Mathf.Max(0, remainDamage - shield);
            //데미지가 더 높다
            if (remainDamage > 0)
            {
                rxShield.Value = 0;
            }
            //낮거나 같은경우 데미지 흡수
            else
            {
                rxShield.Value -= damage;
            }
        }

        rxHp.Value = Mathf.Max(0, hp - remainDamage);
        if (rxHp.Value == 0)
        {
            isDie = true;
        }
    }

    public enum PercentDamageType
    {
        CalcMaxHP,
        CalcCurrentHP,
    }

    public void PercentDamanged(float percent,PercentDamageType type)
    {
        float baseHP = 0;
        if (type == PercentDamageType.CalcMaxHP)
        {
            baseHP = (float)MaxHP;
        }
        else
        {
            baseHP = (float)rxHp.Value;
        }

        float damageHP = baseHP* percent;

        Damaged((int)damageHP);
    }
}
