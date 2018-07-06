using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class CharacterBase
{
    [SerializeField]
    private string className;
    [SerializeField]
    private int hp;
    [SerializeField]
    private int energy;
    public int HP { get { return hp; } }
    public int Energy { get { return energy; } }
    public CharacterBase(string className, int hp, int energy)
    {
        this.className = className;
        this.hp = hp;
        this.energy = energy;
    }

    public JSONObject ToJson()
    {
        JSONObject obj = new JSONObject();
        obj.Add("classname", new JSONString(className));
        obj.Add("hp", new JSONNumber(hp));
        obj.Add("energy", new JSONNumber(energy));

        return obj;
    }

    public static CharacterBase GetJson(JSONObject obj)
    {
        string cname = obj["classname"].ToString();
        int hp = obj["hp"].AsInt;
        int energy = obj["energy"].AsInt;

        return new CharacterBase(cname, hp, energy);
    }

}

public class CharacterBaseCollection
{
    private static string filePath = "Assets/Bundles/Data/CharacterBase.dat";
    private Dictionary<int, CharacterBase> characterMap = null;
    private bool isUpdated = false;
    public CharacterBase Get(int index)
    {
        if (!isUpdated)
        {
            Load();
        }
        if (characterMap.ContainsKey(index))
        {
            return characterMap[index];
        }

        Debug.LogError("Not CharacterBase");
        return null;
    }

    public void GetAsync(int index, Action<CharacterBase> result)
    {

    }

    private void Load()
    {
        characterMap = new Dictionary<int, CharacterBase>();
        var list = DataLoad().GetEnumerator();
        int count = 0;
        while (list.MoveNext())
        {
            var data = list.Current;
            characterMap[count++] = data;
        }

        isUpdated = true;
    }

    #region EXTERNDATA

    public static void DataSave(List<CharacterBase> characterList)
    {
        JSONObject node = new JSONObject();
        JSONArray arr = new JSONArray();
        var iter = characterList.GetEnumerator();
        while (iter.MoveNext())
        {
            arr.Add(iter.Current.ToJson());
        }

        node.Add("arr", arr);

        string jstring = node.ToString();
        
        ExDataCtr.ETSaveData(filePath, jstring);

    }

    public static List<CharacterBase> DataLoad()
    {
        List<CharacterBase> result = new List<CharacterBase>();
        string data = ExDataCtr.ETLoadData(filePath);

        JSONNode node = JSON.Parse(data);
        JSONArray arr = node.AsObject["arr"].AsArray;
        var iter = arr.GetEnumerator();
        while (iter.MoveNext())
        {
            JSONObject loopobj = iter.Current.Value.AsObject;
            CharacterBase item = CharacterBase.GetJson(loopobj);
            result.Add(item);
        }
        return result;
    }

    #endregion

}
