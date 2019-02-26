using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFire : MonoBehaviour {
    public HealthCtr healthCtr = null;
    public void Bind(HealthCtr ctr)
    {
        transform.SetParent(ctr.gameObject.transform);
        healthCtr = ctr;
        healthCtr.SetStat(HealthCtr.HealthStatus.Fire, gameObject);
    }

    private int FireDamage = 0;
    private int FireTime = 0;

    public void StartPosion(int dmg, int time)
    {
        FireDamage = dmg;
        FireTime = time;


        StartCoroutine(Poisoning());
    }

    private IEnumerator Poisoning()
    {
        bool isCure = false;
        while (!isCure)
        {
            yield return new WaitForSeconds(1.0f);

            CalcDamage(FireDamage);
            FireTime--;

            if (FireTime <= 0)
            {
                isCure = true;
            }
        }
        CurePosion();
    }

    private void CalcDamage(int damage)
    {
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
            healthCtr.DamageHP(remainDamage);
        }


    }

    void CurePosion()
    {
        healthCtr.ClearStat(HealthCtr.HealthStatus.Fire);
        healthCtr = null;
        Destroy(gameObject);
    }

    public void AddEffect(int dmg, int time)
    {
        FireDamage += dmg;
        FireTime = Mathf.Max(FireTime, time);
    }
}
