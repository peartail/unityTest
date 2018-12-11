using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MyWarrior : MonoBehaviour {
    private CharacterBaseData baseData;
    private CharacterBaseData curData;
    // Use this for initialization
    private Subject<CharacterBaseData> curStream = new Subject<CharacterBaseData>();
    public IObservable<CharacterBaseData> Ob
    {
        get
        {
            return curStream.AsObservable();
        }
    }

    private void Awake()
    {
        baseData = CharacterBase.Get(CharacterBase.CharacterKind.Boxer);
        curData = baseData;
    }

    private void Start()
    {
        curStream.OnNext(curData);
    }

    private void OnDamaged(int damage)
    {
        curData.hp -= damage;
        curStream.OnNext(curData);
    }

    
}
