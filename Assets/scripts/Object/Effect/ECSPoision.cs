using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ECSPoision : MonoBehaviour {
    public HealthCtr healthCtr;
    public int PoisonDamage;
    public float PoisonTime;
    private bool isCure = false;
    private bool isStart = false;
    private float damageTime;

    public void Init(HealthCtr ctr, int dmg,float time)
    {
        transform.SetParent(ctr.gameObject.transform);
        healthCtr = ctr;
        PoisonDamage = dmg;
        PoisonTime = time;
        damageTime = PoisonTime - 1;
        isStart = true;
        isCure = false;
        healthCtr.SetStat(HealthCtr.HealthStatus.Poison, gameObject);
    }

    public bool IsStart()
    {
        return isStart && !isCure;
    }

    public bool Poisoning(float delattime)
    {
        PoisonTime -= delattime;
        if (PoisonTime < damageTime)
        {
            damageTime -= 1;
            int currenthp = healthCtr.DamageHP(PoisonDamage);

            if (currenthp <= 0)
            {
                isCure = true;
                return true;
            }
        }

        if (PoisonTime <= 0)
        {
            isCure = true;
        }

        return isCure;
    }

    public void EndPoison()
    {
        healthCtr.ClearStat(HealthCtr.HealthStatus.Poison);
        healthCtr = null;
        Destroy(gameObject);
    }

    public void AddEffect(int dmg, int time)
    {
        PoisonDamage += dmg;
        PoisonTime = Mathf.Max(PoisonTime, time);
        damageTime = PoisonTime - 1;
    }
}

public class ECSPoisonSystem : ComponentSystem
{
    struct Components{
        public ECSPoision poison;
        public Transform trans;
    }

    protected override void OnUpdate()
    {
        foreach(var entity in GetEntities<Components>())
        {
            ECSPoision poison = entity.poison;
            if(poison.IsStart())
            {
                if(poison.Poisoning(Time.deltaTime))
                {
                    poison.EndPoison();
                }
            }
        }
    }
}

