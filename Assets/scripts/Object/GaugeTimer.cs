using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class GaugeTimer : MonoBehaviour
{
    public Transform GaugeTrans;
    private static readonly float MaxTransHeight = 1.6f;
    public float energyGauge = 0;
    private float maxEnergy = 10;


    // Use this for initialization
    void Start()
    {
        noIncrease = new ReactiveProperty<bool>(true);
        noIncrease
            .DistinctUntilChanged()
            .Where(inc => inc == false)
            .Subscribe(_ =>
            {
                Debug.Log("Start Increase");
                //StartCoroutine(IncreaseEnergy());
            });



    }

    public void StartIncreaseEnergy()
    {
        Debug.Log("StartGauge");
        noIncrease.Value = false;
    }

    public void UseEnergy()
    {
        if(energyGauge >= 3)
        {
            energyGauge = Mathf.Max(energyGauge - 3, 0);
            noIncrease.Value = false;
        }

    }

    private void Update()
    {
        if (!noIncrease.Value)
        {
            //yield return new WaitForSeconds(0.1f);

            float incPoint = Time.deltaTime * IncForSecond;
            energyGauge = Mathf.Min(energyGauge + incPoint, maxEnergy);

            if (energyGauge == maxEnergy)
            {
                noIncrease.Value = true;
            }

            //현재 퍼센트
            float curpercent = energyGauge / maxEnergy;
            Vector3 gaugeCurrentVec = GaugeTrans.localPosition;
            gaugeCurrentVec.y = curpercent * MaxTransHeight;
            GaugeTrans.localPosition = gaugeCurrentVec;
        }
    }


    private ReactiveProperty<bool> noIncrease;
    private float IncForSecond = 2.0f;
    //private IEnumerator IncreaseEnergy()
    //{

    //}

}
