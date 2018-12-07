using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;




public class BattleStage : MonoBehaviour {

    private Transform StageRoot = null;

    private void Awake()
    {

        StageRoot = GetComponent<Transform>();
    }

    // Use this for initialization
    void Start () {
        TestMemberJoin();
        TestBattleUI();
	}

    void TestMemberJoin()
    {
        var mywar = GameObjectManager.I.SpawnMyWarrior();
        mywar.gameObject.transform.SetParent(StageRoot, false);

        var monslime = GameObjectManager.I.SpawnMonsterSlime();
        monslime.gameObject.transform.SetParent(StageRoot, false);

        GameDataManager.I.GetMonsterData();
    }

    void TestBattleUI()
    {
        var testUI = UIManager.GetUI<battleTestDlg>("battletestDlg");

        UIManager.I.OpenUI(testUI);
    }

    //내 케릭 입장
    public void IamJoin(GameObject ichar)
    {
        ichar.transform.SetParent(StageRoot,false);
    }

    //적 입장
    public void EnemyJoin(GameObject enemychar)
    {
        enemychar.transform.SetParent(StageRoot, false);
    }

    private void InitNormalBattle()
    {

    }
}
