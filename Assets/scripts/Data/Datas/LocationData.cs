using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

public class LocationData : IDataResource
{
    enum LocationType : short
    {
        Monster = 0,
    }


    public JSONNode GetJsonData()
    {
        throw new NotImplementedException();
    }

    public void SetJsonData(JSONNode node)
    {
        throw new NotImplementedException();
    }
}
