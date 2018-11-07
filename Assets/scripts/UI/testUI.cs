using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testUI : MonoBehaviour {

    public BattleStageSpawner spawner;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


	}

    public void BtnSpawnChar()
    {
        //spawner.SpawnMyCharacter();
    }

    public void BtnSpawnBS()
    {
        spawner.SpawnBattleStage();
    }
}
