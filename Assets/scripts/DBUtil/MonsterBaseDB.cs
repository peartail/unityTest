using DBUtil;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class MonsterBaseDB : MonoBehaviour {
    public List<MonsterBaseData> monsterList;


    private static readonly string filePath = "Assets/Bundles/Data/MonsterBase.bytes";
    public void Save()
    {
        WrapperList<MonsterBaseData> item = new WrapperList<MonsterBaseData>(monsterList);

        string jsonData = JsonUtility.ToJson(item);
        File.WriteAllText(filePath, jsonData);
    }

    public void Load()
    {
        string resultData = File.ReadAllText(filePath);
        var list = JsonUtility.FromJson<WrapperList<MonsterBaseData>>(resultData);
        monsterList = list.data;
    }


}

#if UNITY_EDITOR
[CustomEditor(typeof(MonsterBaseDB))]
public class MonsterDBDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MonsterBaseDB myScript = (MonsterBaseDB)target;
        if (GUILayout.Button("Save MonsterData"))
        {
            myScript.Save();
        }
        if (GUILayout.Button("Load MonsterData"))
        {
            myScript.Load();
        }
    }
}
#endif