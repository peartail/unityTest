using DDatas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class testInitializer : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        isInitailize = new ReactiveProperty<bool>(false);
        StartCoroutine(ItemInit());
    }

    private IEnumerator ItemInit()
    {
        yield return null;
        InitTestBattleCard();
        InitTestActor();
        isInitailize.Value = true;
    }
    public ReactiveProperty<bool> isInitailize = null;

    // Update is called once per frame
    private void InitTestBattleCard()
    {
        BattleActorBox.AddBattleCard(DataActCardBox.GetData(0));
        BattleActorBox.AddBattleCard(DataActCardBox.GetData(0));
        BattleActorBox.AddBattleCard(DataActCardBox.GetData(0));
        BattleActorBox.AddBattleCard(DataActCardBox.GetData(0));

        BattleActorBox.AddBattleCard(DataActCardBox.GetData(1));
        BattleActorBox.AddBattleCard(DataActCardBox.GetData(1));
        BattleActorBox.AddBattleCard(DataActCardBox.GetData(1));
        BattleActorBox.AddBattleCard(DataActCardBox.GetData(1));

        BattleActorBox.AddBattleCard(DataActCardBox.GetData(2));
        BattleActorBox.AddBattleCard(DataActCardBox.GetData(2));
    }

    private void InitTestActor()
    {
        BattleActorBox.AddBattleMyActor(DataMyActorBox.GetData(DataMyActorKind.Treveler));
    }


}
