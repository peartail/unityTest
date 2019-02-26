using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackHelper : IDisposable
{
    private HealthCtr healthCtr = null;

    public NormalAttackHelper(HealthCtr ctr)
    {
        healthCtr = ctr;
    }


    public void NormalAttack( int damage)
    {
        if (healthCtr == null)
            return;

        int remainDamage = damage;
        if (healthCtr.GetShield() > 0)
        {
            int remainshield = healthCtr.DamageShield(damage);
            remainDamage = 0;
            if (remainshield < 0)
            {
                remainDamage = -remainshield;
            }
        }

        if (remainDamage > 0)
        {
            int remainHP = healthCtr.DamageHP(remainDamage);
        }
    }

    public void PercentageAttack(float percent, bool calcMaxHP)
    {
        if (healthCtr == null)
            return;

        healthCtr.CustomDamage((hp, shield, maxHP) =>
        {
            float baseHP = 0;
            if (calcMaxHP)
            {
                baseHP = (float)maxHP;
            }
            else
            {
                baseHP = (float)hp.Value;
            }

            float damageHP = baseHP * percent;

            NormalAttack((int)damageHP);
        });
    }

    public void PoisonAttack(int value, int time)
    {
        if (healthCtr.GetHealthStat(HealthCtr.HealthStatus.Poison) == null)
        {
            ECSPoision poison = ObjectLoadMgr.LoadAsset<ECSPoision>("Effect/DamagePosion");
            poison?.Init(healthCtr, value, time);
        }
        else
        {
            healthCtr?.GetHealthStat(HealthCtr.HealthStatus.Poison)?.GetComponent<ECSPoision>()?.AddEffect(3, 5);
        }
    }

    public void FireAttack(int value, int time)
    {
        if (healthCtr.GetHealthStat(HealthCtr.HealthStatus.Fire) == null)
        {
            ECSFire posion = ObjectLoadMgr.LoadAsset<ECSFire>("Effect/DamageFire");
            posion?.Init(healthCtr, value, time);
        }
        else
        {
            healthCtr?.GetHealthStat(HealthCtr.HealthStatus.Fire)?.GetComponent<ECSFire>()?.AddEffect(3, 5);
        }
    }

    bool disposed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
        }

        disposed = true;
    }
}
