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
    public CharacterBaseCollection collection = new CharacterBaseCollection();
    private string path = "/Asset/Resource/CharacterBase.data";
	// Use this for initialization
	public void Save()
    {
        if(File.Exists(path))
        {
            JSONObject node = new JSONObject();
            JSONArray arr = new JSONArray();
            var iter = characterList.GetEnumerator();
            while(iter.MoveNext())
            {
                arr.Add(iter.Current.ToJson());
            }

            node.Add("arr", arr);

            string jstring = node.ToString();

            File.WriteAllText(path, jstring);

        }
    }

    public void Load()
    {
        if (!File.Exists(path))
        {
            Debug.LogError("먼저 저장부터해주세요.");
            return;
        }



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