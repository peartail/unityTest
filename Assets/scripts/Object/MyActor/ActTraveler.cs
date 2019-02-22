using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DDatas;
using UniRx;

public class ActTraveler : MonoBehaviour {

    private ReactiveProperty<DataMyActor> curInfo = null;
    public HealthCtr healthCtr = null;
    // Use this for initialization
    void Awake () {

	}

    private void Start()
    {

    }

    public void Init()
    {
        curInfo = new ReactiveProperty<DataMyActor>();
        curInfo.Value = DataMyActorBox.GetData(DataMyActorKind.Treveler);
        InitHealthCtr();
    }

    //있다는 가정하에
    private void InitHealthCtr()
    {
        ReactiveProperty<int> rxHp = new ReactiveProperty<int>(curInfo.Value.Hp);
        ReactiveProperty<int> rxShield = new ReactiveProperty<int>(curInfo.Value.Shield);
        rxHp.DistinctUntilChanged().Subscribe(x =>
        {
            var v = curInfo.Value;
            v.Hp = x;
            curInfo.Value = v;
        });

        rxShield.DistinctUntilChanged().Subscribe(x =>
        {
            var v = curInfo.Value;
            v.Shield = x;
            curInfo.Value = v;
        });

        healthCtr.InitHealth(rxShield, rxHp,curInfo.Value.MaxHp);
    }

    public DataMyActor GetInfo { get { return curInfo.Value; } }
    public System.IObservable<DataMyActor> InfoOb { get { return curInfo.DistinctUntilChanged(); } }
    private Subject<DataMyActor> subject;

}
