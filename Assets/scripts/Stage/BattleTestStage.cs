using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class BattleTestStage : MonoBehaviour {

    private CharacterData myCharData = null;
    public CharacterData MyCharData {  get { return myCharData; } }
	// Use this for initialization
	void Start () {
        DataBox box = null;
        using (var data = new WarehouseManager())
        {
            data.NewWarehouse();
            box = data.CurrentBox;
        }

        myCharData = box.GetDataRX<CharacterData>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
