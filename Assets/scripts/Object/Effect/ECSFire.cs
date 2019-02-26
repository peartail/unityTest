using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ECSFire : MonoBehaviour {

    public HealthCtr healthCtr;
    public int FireDamage;
    public float FireTime;
    private bool isCure = false;
    private bool isStart = false;
    private float damageTime;

    public void Init(HealthCtr ctr, int dmg, float time)
    {
        transform.SetParent(ctr.gameObject.transform);
        healthCtr = ctr;
        FireDamage = dmg;
        FireTime = time;
        damageTime = FireTime - 1;
        isStart = true;
        isCure = false;
        healthCtr.SetStat(HealthCtr.HealthStatus.Fire, gameObject);
    }

    public bool IsStart()
    {
        return isStart && !isCure;
    }

    public bool Firing(float delattime)
    {
        FireTime -= delattime;
        if (FireTime < damageTime)
        {
            damageTime -= 1;
            int currenthp = CalcDamage(FireDamage);

            if (currenthp <= 0)
            {
                isCure = true;
                return true;
            }
        }

        if (FireTime <= 0)
        {
            isCure = true;
        }

        return isCure;
    }

    private int CalcDamage(int damage)
    {
        int currentHP = healthCtr.GetHP();
        int remainDamage = damage;
        if (healthCtr.GetShield() > 0)
        {
            int currentShield = healthCtr.DamageShield(damage * 2);
            remainDamage = 0;
            if (currentShield < 0)
            {
                remainDamage = -currentShield / 2;
            }
        }

        if (remainDamage > 0)
        {
            currentHP = healthCtr.DamageHP(remainDamage);
        }

        return currentHP;
    }

    public void EndFire()
    {
        healthCtr.ClearStat(HealthCtr.HealthStatus.Fire);
        healthCtr = null;
        Destroy(gameObject);
    }

    public void AddEffect(int dmg, int time)
    {
        FireDamage += dmg;
        FireTime = Mathf.Max(FireTime, time);
        damageTime = FireTime - 1;
    }
}



public class ECSFireSystem : ComponentSystem
{
    struct Components
    {
        public ECSFire fire;
        public Transform trans;
    }

    protected override void OnUpdate()
    {
        foreach (var entity in GetEntities<Components>())
        {
            ECSFire poison = entity.fire;
            if (poison.IsStart())
            {
                if (poison.Firing(Time.deltaTime))
                {
                    poison.EndFire();
                }
            }
        }
    }
}

