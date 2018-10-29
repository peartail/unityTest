using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class CharacterBaseData
{
    [SerializeField]
    public string name;
    [SerializeField]
    public int hp;
    [SerializeField]
    public int atk;
    [SerializeField]
    public int def;
}


public class CharacterBase : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
