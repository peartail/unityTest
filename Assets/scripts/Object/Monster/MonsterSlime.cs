using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MonsterSlime : MonoBehaviour {
    private MonsterBaseData baseData;
    private MonsterBaseData curData;
    private static readonly MonsterBase.MonsterKind index = MonsterBase.MonsterKind.MonsterSlime;
    private Subject<MonsterBaseData> curStream = new Subject<MonsterBaseData>();
    public IObservable<MonsterBaseData> Ob
    {
        get
        {
            return curStream.AsObservable();
        }
    }
    
    private void Awake()
    {
        baseData = MonsterBase.Get(index);
        curData = baseData;

    }
    void Start()
    {
        curStream.OnNext(curData);
    }

    public void OnDamaged(int damage)
    {
        curData.hp -= damage;
        curStream.OnNext(curData);
    }
}
