using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterBaseDB : MonoBehaviour {
    public List<CharacterBase> characterList = new List<CharacterBase>();
    private string path = "/Asset/";
	// Use this for initialization
	public void Save()
    {

    }
}

[CustomEditor(typeof(CharacterBaseDB))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CharacterBaseDB myScript = (CharacterBaseDB)target;
        if (GUILayout.Button("Save LevelData"))
        {
            myScript.Save();
        }
    }
}