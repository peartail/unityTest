using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterBaseDB : MonoBehaviour {

    public void Save()
    {
    }

    public void Load()
    {
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