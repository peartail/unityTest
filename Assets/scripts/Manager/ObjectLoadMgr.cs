using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoadMgr
{
    private List<GameObject> loadedObjs = null;
    private GameObject cachedObjs = null;
    private readonly string OPath = "Object/";
    private readonly string Ext = ".prefab";
    private bool isInit = false;
    private static ObjectLoadMgr i = null;
    private static ObjectLoadMgr I
    {
        get
        {
            if(i == null)
            {
                i = new ObjectLoadMgr();
            }
            return i;
        }
    }

    private void Init()
    {
        isInit = true;
        loadedObjs = new List<GameObject>();
    }

    private GameObject Inst(GameObject origin)
    {
        return Object.Instantiate(origin);
    }


    private T LA<T>(string name) where T : class
    {
        if(!isInit)
        {
            Init();
        }

        if (cachedObjs != null && cachedObjs.name == name)
        {
            return Inst(cachedObjs).GetComponent<T>();
        }

        var iter = loadedObjs.GetEnumerator();
        while (iter.MoveNext())
        {
            if(iter.Current.name == name)
            {
                return Inst(iter.Current).GetComponent<T>();
            }
        }

        using (AssetLoader loader = new AssetLoader())
        {
            var item = loader.Load<GameObject>(OPath + name + Ext);
            if(item != null)
            {
                cachedObjs = item;
                loadedObjs.Add(item);
                return Inst(item).GetComponent<T>();
            }
        }
        return null;
    }


    public static T LoadAsset<T>(string name) where T : class
    {
        return I.LA<T>(name);
    }

}
