using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.Entities;
using UnityEngine;

public class ECSGaugeTimer : MonoBehaviour {
    public Transform GaugeTrans;
    private static readonly float MaxTransHeight = 1.6f;
    private float energyGauge = 0;
    private float maxEnergy = 10;
    private bool noIncrease = true;
    private float IncForSecond = 1.0f;

    // Use this for initialization
    void Start()
    {

    }

    public bool IsIncrease()
    {
        return !noIncrease;
    }

    public void StartIncreaseEnergy()
    {
        Debug.Log("StartIncrease");
        noIncrease = false;
    }

    public void UseEnergy(int enegy)
    {
        if (energyGauge >= enegy)
        {
            energyGauge = Mathf.Max(energyGauge - enegy, 0);
            noIncrease = false;
        }
    }

    public void GaugeUpdate(float deltaTime)
    {
        if (!noIncrease)
        {
            float incPoint = deltaTime * IncForSecond;
            energyGauge = Mathf.Min(energyGauge + incPoint, maxEnergy);

            if (energyGauge == maxEnergy)
            {
                noIncrease = true;
            }

            //현재 퍼센트
            float curpercent = energyGauge / maxEnergy;
            Vector3 gaugeCurrentVec = GaugeTrans.localPosition;
            gaugeCurrentVec.y = curpercent * MaxTransHeight;
            GaugeTrans.localPosition = gaugeCurrentVec;
        }
    }

}

public class GaugeTimerSystem : ComponentSystem
{
    struct Components
    {
        public ECSGaugeTimer timer;
    }

    protected override void OnUpdate()
    {
        foreach(var entity in GetEntities<Components>())
        {
            if(entity.timer.IsIncrease())
            {
                entity.timer.GaugeUpdate(Time.deltaTime);
            }

        }
    }
}
