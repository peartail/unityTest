using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeTurn : MonoBehaviour
{
    private float energy = 0.0f;

    public int Energy
    {
        get
        {
            return Mathf.FloorToInt(energy);
        }
    }

    private void Start()
    {

    }

    //게이지를 갱신
    private void UpdateGauge()
    {
        energy = Mathf.Clamp(CalculateGauge(Time.deltaTime),0,maxEnergy);
    }

    private float gaugeSpeedOnSecond = 1.0f;
    private float maxEnergy = 10.0f;

    //게이지 증가 계산
    private float CalculateGauge(float deltatime)
    {
        float tempEnergy = deltatime * gaugeSpeedOnSecond; ;
        //버프량 추가

        return tempEnergy;
    }
}
