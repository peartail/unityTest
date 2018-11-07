using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;


enum TurnState
{
    MyTurn = 1,
    MonsterTurn = 2,
}

class TurnManager
{
    private List<TurnState> PriorityList = null;

    internal void Init(List<TurnState> list)
    {
        PriorityList = list;
    }

}

public class BattleStage : MonoBehaviour {

    private Transform StageRoot = null;
    TurnManager manager = null;

    private void Awake()
    {
        StageRoot = GetComponent<Transform>();
    }

    // Use this for initialization
    void Start () {

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
        manager = new TurnManager();

        List<TurnState> list = new List<TurnState>();
        list.Add(TurnState.MyTurn);
        list.Add(TurnState.MonsterTurn);
        manager.Init(list);
    }
}
