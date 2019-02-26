using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamagePoison : MonoBehaviour {
    public HealthCtr healthCtr = null;
    public void Bind(HealthCtr ctr)
    {
        transform.SetParent(ctr.gameObject.transform);
        healthCtr = ctr;
        healthCtr.SetStat(HealthCtr.HealthStatus.Poison,gameObject);
    }

    private int PoisonDamage = 0;
    private int PoisonTime = 0;
    private bool isCure = false;
	// Use this for initialization
    public void StartPosion(int dmg,int time)
    {
        PoisonDamage = dmg;
        PoisonTime = time;
        isCure = false;

        StartCoroutine(Poisoning());
    }

    private IEnumerator Poisoning()
    {
        while(!isCure)
        {
            yield return new WaitForSeconds(1.0f);

            int currenthp = healthCtr.DamageHP(PoisonDamage);

            if (currenthp <= 0)
            {
                isCure = true;
                break;
            }

            PoisonTime--;

            if(PoisonTime <= 0)
            {
                isCure = true;
            }
        }
        CurePosion();
    }

    void CurePosion()
    {
        healthCtr.ClearStat(HealthCtr.HealthStatus.Poison);
        healthCtr = null;
        Destroy(gameObject);
    }

    public void AddEffect(int dmg,int time)
    {
        PoisonDamage += dmg;
        PoisonTime = Mathf.Max(PoisonTime, time);
    }
}
