using DBUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct MonsterBaseData
{
    [SerializeField]
    public MonsterBase.MonsterKind index;
    [SerializeField]
    public string name;
    [SerializeField]
    public int hp;

    public MonsterBaseData(MonsterBaseData r)
    {
        index = r.index;
        name = r.name;
        hp = r.hp;
    }
}


public static class MonsterBase  {
    public enum MonsterKind : int
    {
        MonsterSlime = 1,
    }

    private static List<MonsterBaseData> monsters = null;
    private static readonly string monsterdb = "Data/MonsterBase.bytes";
    private static bool isLoad = false;
    private static void Load()
    {
        if (isLoad)
            return;

        using (var loader = new AssetLoader())
        {
            TextAsset asset = loader.Load<TextAsset>(monsterdb);
            WrapperList<MonsterBaseData> wdata = JsonUtility.FromJson<WrapperList<MonsterBaseData>>(asset.text);
            monsters = wdata.data;
            isLoad = true;
        }
    }
    
    public static MonsterBaseData Get(MonsterKind index)
    {
        Load();
        return monsters.Find((x) =>
        {
            return x.index == index;
        });
    }

    public static MonsterBaseData Find(string name)
    {
        Load();
        return monsters.Find((x) =>
        {
            return x.name == name;
        });
    }
}
