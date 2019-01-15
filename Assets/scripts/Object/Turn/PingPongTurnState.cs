using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PingPongTurnState {

    public enum ePingPongTurnState
    {
        MyTurn,
        EnemyTurn,
    }
    private ReactiveProperty<ePingPongTurnState> curState = null;
    private IObservable<ePingPongTurnState> obchanged = null;
    public IObservable<ePingPongTurnState> ObChanged
    {
        get
        {
            return obchanged;
        }
    }

    public PingPongTurnState()
    {
        curState = new ReactiveProperty<ePingPongTurnState>();
        obchanged = curState.DistinctUntilChanged();
    }



    public void MyTurnEnd()
    {
        curState.Value = ePingPongTurnState.EnemyTurn;
    }
    public void EnemyTurnEnd()
    {
        curState.Value = ePingPongTurnState.MyTurn;
    }

}
