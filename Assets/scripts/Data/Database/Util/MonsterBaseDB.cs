using Monster;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterBaseDB : MonoBehaviour {
    public List<MonsterBase> monsters = new List<MonsterBase>();
    public readonly static string filePath = "Assets/Bundles/Data/MonsterBase.dbdata";
    public void Save()
    {
        ExDataCtr.ETSaveData(filePath, MonsterBaseCollection.DataToJson(monsters));
    }

    public void Load()
    {
        string data = ExDataCtr.ETLoadData(filePath);
        JSONNode node = JSON.Parse(data);
        monsters = MonsterBaseCollection.JsonToData(node.AsObject);
    }

}


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