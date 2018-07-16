using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

using UniRx;
public class MonsterData : IDataResource
{
    public ReactiveProperty<int> HP = null;
    private int monsterKind = 0;
    private MonsterBase baseData = null;
    private Subject<MonsterData> sub = null;
    public IObservable<MonsterData> Ob { get { return sub.AsObservable(); } }
    public MonsterBase BaseData { get { return baseData; } }
    public MonsterData(MonsterBase db)
    {
        HP = new ReactiveProperty<int>();
        HP.Value = db.HP;
        this.monsterKind = db.MonsterKind;
        this.baseData = db;

        sub = new Subject<MonsterData>();
        HP.Subscribe(hp =>
        {
            sub.OnNext(this);
        });
    }

    

    public string GetName()
    {
        return baseData.MonsterName;
    }


    public JSONNode GetJsonData()
    {
        JSONObject obj = new JSONObject();
        obj.Add("HP", new JSONNumber(HP.Value));
        obj.Add("kind", new JSONNumber(monsterKind)); 
        return obj;
    }

    public void SetJsonData(JSONNode node)
    {
        var obj = node.AsObject;
        HP.Value = obj["HP"].AsInt;
        monsterKind = obj["kind"].AsInt;
    }
}
