using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

public class MapData : IDataResource
{
    HashSet<LocationData> locationList;

    public MapData()
    {
        locationList = new HashSet<LocationData>();
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
