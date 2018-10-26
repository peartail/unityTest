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

    TurnManager manager = null;
	// Use this for initialization
	void Start () {
        InitNormalBattle();
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
