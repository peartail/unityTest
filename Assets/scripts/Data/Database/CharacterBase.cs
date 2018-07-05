using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterBase {
    [SerializeField]
    private int index;
    [SerializeField]
    private int level;
    [SerializeField]
    private int hp;
    [SerializeField]
    private int energy;
    public int HP { get { return hp; } }
    public int Energy { get { return energy; } }
    public CharacterBase(int index,int level, int hp,int energy)
    {
        this.index = index;
        this.level = level;
        this.hp = hp;
        this.energy = energy;
    }

    
}

public class CharacterBaseCollection
{
    private string filePath = "";
    private Dictionary<int, CharacterBase> characterMap = null;
    private bool isUpdated = false;
    public CharacterBase Get(int index)
    {
        if(!isUpdated)
        {
            Load();
        }
        if(characterMap.ContainsKey(index))
        {
            return characterMap[index];
        }
        
        Debug.LogError("Not CharacterBase");
        return null;
    }

    public void GetAsync(int index,Action<CharacterBase> result)
    {
        
    }

    public void Load()
    {
        string data = ExDataReader.G.GetData(filePath);

        JSONNode node = JSON.Parse(data);
        JSONArray arr = node.AsObject["c"].AsArray;
        var iter = arr.GetEnumerator();
        while(iter.MoveNext())
        {
            JSONObject loopobj = iter.Current.Value.AsObject;
            
        }


        isUpdated = true;
    }
}
