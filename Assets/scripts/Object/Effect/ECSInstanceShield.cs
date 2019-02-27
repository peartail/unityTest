using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.Entities;
using UnityEngine;


public class InstanceShield
{
    internal ReactiveProperty<int> shieldPoint = null;
    internal float shieldTime = 0;
    public InstanceShield(int value,float time)
    {
        shieldPoint = new ReactiveProperty<int>(value);
        shieldTime = time;
    }
}

public class ECSInstanceShield : MonoBehaviour {
    internal List<InstanceShield> shieldLists = new List<InstanceShield>();
    HealthCtr healthCtr = null;
    private void Awake()
    {
        if(shieldLists == null)
        {
            shieldLists = new List<InstanceShield>();
        }
    }

    public void Bind(HealthCtr ctr)
    {
        healthCtr = ctr;
        transform.SetParent(ctr.gameObject.transform);
    }

    public void StartShield(int value,float time)
    {
        var shield = new InstanceShield(value, time);
        shield.shieldPoint.DistinctUntilChanged().Where(x => x <= 0)
            .Subscribe(_ =>
            {
                shieldLists.Remove(shield);
            });

        shieldLists.Add(shield);
        healthCtr.AddInstanceShield(shield.shieldPoint);
    }

}


public class ECSInstanceShieldSystem : ComponentSystem
{
    struct Components
    {
        public ECSInstanceShield Instanceshield;
    }

    protected override void OnUpdate()
    {
        foreach(var entity in GetEntities<Components>())
        {
            var shieldLists = entity.Instanceshield.shieldLists;
            bool isRemovable = false;
            foreach (var shield in shieldLists)
            {
                shield.shieldTime -= Time.deltaTime;
                if (shield.shieldTime < 0)
                {
                    shield.shieldPoint.Value = 0;
                    isRemovable = true;
                }
            }

            if(isRemovable)
            {
                shieldLists.RemoveAll(x => x.shieldPoint.Value <= 0);
            }

        }
    }
}

