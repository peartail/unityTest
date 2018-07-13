using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System;
using SimpleJSON;
using Data;

public sealed class DummyData : IDataResource{
    public ReactiveProperty<int> count = null;
   
    public DummyData()
    {
        count = new ReactiveProperty<int>(0);
   
    }
    

    public JSONNode GetJsonData()
    {
        JSONObject jobj = new JSONObject();
        JSONNumber jcount = new JSONNumber(count.Value);
        jobj.Add("count", jcount);

        return jobj;
    }

    public void SetJsonData(JSONNode node)
    {
        var jobj = node as JSONObject;
        count.Value = (jobj["count"] as JSONNumber).AsInt;

    }

    public override string ToString()
    {
        return "DummyData";
    }
}
