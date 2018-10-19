using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStageSpawner : MonoBehaviour {

    public Transform rootTransform;
	// Use this for initialization
	void Start () {
        SpawnBattleStage();

    }

	// Update is called once per frame
	void Update () {



	}

    private static string battleScenePath = "Field/BattleStage.prefab";
    void SpawnBattleStage()
    {
        using (AssetLoader loader = new AssetLoader())
        {
            var asset = loader.LoadAsset<GameObject>(battleScenePath);
            if(asset != null)
            {
                asset.transform.SetParent(rootTransform, false);
            }

        }

    }
}
