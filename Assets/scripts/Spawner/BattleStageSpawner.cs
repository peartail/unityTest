using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStageSpawner : MonoBehaviour {

    public Transform rootTransform;
    private GameObject myCharacter = null;
	// Use this for initialization
	void Start () {
    }

	// Update is called once per frame
	void Update () {



	}

    private static string myCharacterPath = "Object/MyCharacter.prefab";
    private static string battleScenePath = "Field/BattleStage.prefab";

    //내 케릭터 로드
    public void SpawnMyCharacter()
    {
        using (AssetLoader loader = new AssetLoader())
        {
            var asset = loader.LoadAsset<GameObject>(myCharacterPath);
            if(asset != null)
            {
                myCharacter = asset;
            }
        }
    }


    public void SpawnBattleStage()
    {
        using (AssetLoader loader = new AssetLoader())
        {
            var asset = loader.LoadAsset<GameObject>(battleScenePath);
            if(asset != null)
            {
                asset.transform.SetParent(rootTransform, false);
                BattleStage bs = asset.GetComponent<BattleStage>();
                if(bs != null)
                {
                    var mychar = loader.LoadAsset<GameObject>(myCharacterPath);
                    bs.IamJoin(mychar);
                }
            }

        }
    }
}
