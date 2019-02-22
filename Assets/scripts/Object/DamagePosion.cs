using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePosion : MonoBehaviour {

    public HealthCtr healthCtr = null;
    public void Bind(HealthCtr ctr)
    {
        healthCtr = ctr;
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

            healthCtr.Damaged(PoisonDamage);
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
        Destroy(gameObject);
    }

    void AddPosion()
    {

    }
}
