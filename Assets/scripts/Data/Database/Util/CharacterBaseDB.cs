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
    private string path = "/Asset/Resource/CharacterBase.data";
	// Use this for initialization
	public void Save()
    {
        CharacterBaseCollection.DataSave(characterList);
    }

    public void Load()
    {
        if (!File.Exists(path))
        {
            Debug.LogError("먼저 저장부터해주세요.");
            return;
        }

        characterList = CharacterBaseCollection.DataLoad();

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