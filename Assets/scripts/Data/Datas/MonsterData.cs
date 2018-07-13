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

    MonsterData(Monster.MonsterBase db)
    {
        
    }


    public JSONNode GetJsonData()
    {
        JSONObject obj = new JSONObject();
        obj.Add("HP", new JSONNumber(HP.Value));
        return obj;
    }

    public void SetJsonData(JSONNode node)
    {
        var obj = node.AsObject;
        HP.Value = obj["HP"].AsInt;
    }
}
