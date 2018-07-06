using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class CharacterBaseDB : MonoBehaviour {
    public List<CharacterBase> characterList = new List<CharacterBase>();
    public readonly static string filePath = "Assets/Bundles/Data/CharacterBase.dat";
    // Use this for initialization
    public void Save()
    {
        ExDataCtr.ETSaveData(filePath, CharacterBaseCollection.DataToJson(characterList));
    }

    public void Load()
    {
        string data = ExDataCtr.ETLoadData(filePath);
        JSONNode node = JSON.Parse(data);
        characterList = CharacterBaseCollection.JsonToData(node.AsObject);
    }
    
}

[CustomEditor(typeof(CharacterBaseDB))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CharacterBaseDB myScript = (CharacterBaseDB)target;
        if (GUILayout.Button("Save CharacterData"))
        {
            myScript.Save();
        }

        if(GUILayout.Button("Load CharacterData"))
        {
            myScript.Load();
        }
    }
}