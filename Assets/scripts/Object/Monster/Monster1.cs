using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using DDatas;
using Unity.Entities;
using System;

public class Monster1 : MonoBehaviour {
    private ReactiveProperty<DataMonster> rxMonsterData = null;
    public HealthCtr healthCtr = null;
    // Use this for initialization
	void Start () {

	}

    public void Init()
    {
        rxMonsterData = new ReactiveProperty<DataMonster>();
        rxMonsterData.Value = DataMonsterBox.GetData(DataMonsterKind.Monster1);
        InitHealthCtr();
    }


    private void InitHealthCtr()
    {
        ReactiveProperty<int> hp = new ReactiveProperty<int>(rxMonsterData.Value.hp);
        ReactiveProperty<int> shield = new ReactiveProperty<int>(rxMonsterData.Value.Shield);
        hp.DistinctUntilChanged().Subscribe(x =>
        {
            var v = rxMonsterData.Value;
            v.hp = x;
            rxMonsterData.Value = v;
        });

        shield.DistinctUntilChanged().Subscribe(x =>
        {
            var v = rxMonsterData.Value;
            v.Shield = x;
            rxMonsterData.Value = v;
        });

        healthCtr.InitHealth(shield, hp,  rxMonsterData.Value.maxHp);
    }

    public DataMonster GetInfo { get { return rxMonsterData.Value; } }
    public System.IObservable<DataMonster> GetOb {  get { return rxMonsterData.DistinctUntilChanged(); } }


    private void SelectSkill()
    {

    }
    private void UseSkill()
    {

    }

}

public class Monster1System : ComponentSystem
{
    struct Components
    {
        public Monster1 monster;
    }

    protected override void OnUpdate()
    {
    }
}
