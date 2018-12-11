using DBUtil;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CharacterBaseDB : MonoBehaviour {
    public List<CharacterBaseData> characterList;

    private static readonly string filePath = "Assets/Bundles/Data/CharacterBase.bytes";
    // Use this for initialization
    public void Save()
    {
        WrapperList<CharacterBaseData> item = new WrapperList<CharacterBaseData>(characterList);

        string jsonData = JsonUtility.ToJson(item);
        File.WriteAllText(filePath, jsonData);
    }

    public void Load()
    {
        string resultData = File.ReadAllText(filePath);
        var list = JsonUtility.FromJson<WrapperList<CharacterBaseData>>(resultData);
        characterList = list.data;
    }


}

#if UNITY_EDITOR
[CustomEditor(typeof(CharacterBaseDB))]
public class CharacterDBDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CharacterBaseDB myScript = (CharacterBaseDB)target;
        if (GUILayout.Button("Save CharacterData"))
        {
            myScript.Save();
        }
        if (GUILayout.Button("Load CharacterData"))
        {
            myScript.Load();
        }
    }
}
#endif