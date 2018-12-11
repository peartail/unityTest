using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;




public class BattleStage : MonoBehaviour {

    private Transform StageRoot = null;
    private battleTestDlg battleUI = null;
    private IObservable<CharacterBaseData> myCharOb;
    private IObservable<MonsterBaseData> MonOb;
    private ABattleTurnState testTurnS = null;
    private void Awake()
    {

        StageRoot = GetComponent<Transform>();

        TestBattleUI();
        TestMemberJoin();
        TestSetEvent();
    }

    // Use this for initialization
    void Start () {
        battleUI.AddLog("BattleStart!");
        battleUI.AddLog(testTurnS.GetCurrentTurn.ToString());
	}

    void OnTurnEnd()
    {
        var nextTurn = testTurnS.NextTurn();
        battleUI.AddLog("CurrentTurn : " + nextTurn.ToString());
    }
    
    private void TestMemberJoin()
    {
        var mywar = GameObjectManager.I.SpawnMyWarrior();
        mywar.gameObject.transform.SetParent(StageRoot, false);
        myCharOb = mywar.Ob;
        

        var monslime = GameObjectManager.I.SpawnMonsterSlime();
        monslime.gameObject.transform.SetParent(StageRoot, false);
        MonOb = monslime.Ob;

        testTurnS = new ABattleTurnState(2);
    }

    private void TestBattleUI()
    {
        var testUI = UIManager.GetUI<battleTestDlg>("battletestDlg");
        battleUI = testUI;
        UIManager.I.OpenUI(testUI);
    }

    private void TestSetEvent()
    {
        myCharOb.Subscribe(battleUI.OnCharacterInfoSubscribe);
        MonOb.Subscribe(battleUI.OnMonsterInfoSubscribe);
        battleUI.TurnEndAction = OnTurnEnd;
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
