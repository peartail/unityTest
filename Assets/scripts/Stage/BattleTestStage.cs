
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System.Text;
using System;

public class BattleTestStage : MonoBehaviour {

    enum ETurnType
    {
        PrepareMyTurn,
        MyTurn,
        PrepareYourTurn,
        YourTurn,
        EndStage,
    }
    #region Event
    Subject<string> logSubject = new Subject<string>();
    public IObservable<string> logOb { get { return logSubject.AsObservable(); } }

    #endregion

    StringBuilder LogText = new StringBuilder();
    bool IsBattlePrepared = false;
	// Use this for initialization
	void Awake () {

	}

    private void Start()
    {
        if(IsBattlePrepared)
        {
            StartBattle();
        }
    }

    private void StartBattle()
    {
        AddLog("BattleStart!");

    }

    private void OnTurnEnd()
    {

    }

    private void StageOver()
    {

    }

    private void AddLog(string log)
    {
        LogText.AppendFormat(log);
        LogText.Append("\n");
        logSubject.OnNext(LogText.ToString());

    }

}
