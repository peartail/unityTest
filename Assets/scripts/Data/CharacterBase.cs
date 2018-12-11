using DBUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct CharacterBaseData
{
    [SerializeField]
    public CharacterBase.CharacterKind kind;
    [SerializeField]
    public string name;
    [SerializeField]
    public int hp;
    [SerializeField]
    public int atk;
    [SerializeField]
    public int def;
}


public static class CharacterBase {
    public enum CharacterKind
    {
        Boxer = 1,
        Unded = 2,
    }
    private static List<CharacterBaseData> characters = null;
    private static readonly string characterdb = "Data/CharacterBase.bytes";
    private static bool isLoad = false;
    private static void Load()
    {
        if (isLoad)
            return;

        using (var loader = new AssetLoader())
        {
            TextAsset asset = loader.Load<TextAsset>(characterdb);
            WrapperList<CharacterBaseData> wdata = JsonUtility.FromJson<WrapperList<CharacterBaseData>>(asset.text);
            characters = wdata.data;
            isLoad = true;
        }
    }

    public static CharacterBaseData Get(CharacterKind index)
    {
        Load();
        return characters.Find((x) =>
        {
            return x.kind == index;
        });
    }

    public static CharacterBaseData Find(string name)
    {
        Load();
        return characters.Find((x) =>
        {
            return x.name == name;
        });
    }
}
