﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EffectShield : MonoBehaviour {

	// Use this for initialization
    private bool isEnd = false;
    private HealthCtr currentCtr = null;
    private int shieldIndex = 0;
    private int currentTime;
    public void Bind(HealthCtr ctr)
    {

        //shields = new Queue<InstanceShield>();
        //currentCtr = ctr;
    }

    void StartShield(int value,int time)
    {
        //InstanceShield shield = new InstanceShield(shieldIndex++, value,time);
        //shields.Enqueue(shield);
        //StartCoroutine(ShieldEffect());
    }

    private IEnumerator ShieldEffect()
    {
        yield return null;
        //while (shields.Count > 0)
        //{
        //    yield return new WaitForSeconds(1.0f);
        //    InstanceShield shield = shields.Dequeue();
        //    shield.time--;
        //    shields.Enqueue(shield);
        //}
        //EndShield();
    }

    void EndShield()
    {

    }
}
