using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using System.Text;
using System;
using UnityEngine.Events;

public class battleTestDlg : MonoBehaviour,CUI {

    public BattleTestStage stageInfo;

    public Text logText;
    public Text CharInfoTxt;
    public Text MonInfoTxt;
    public Button atBtn;
    public Button turnEnd;

    public UnityAction TurnEndAction = null; 

    private StringBuilder logstr = new StringBuilder();
    private void Awake()
    {
        turnEnd.onClick.AddListener(OnTurnEnd);
    }

    private void OnTurnEnd()
    {
        if(TurnEndAction != null)
        {
            TurnEndAction();
        }
    }

    public void OnCharacterInfoSubscribe(CharacterBaseData data)
    {
        CharInfoTxt.text = string.Format("Char Name : {0} \n HP : {1}",data.name,data.hp);
    }

    public void OnMonsterInfoSubscribe(MonsterBaseData data)
    {
        MonInfoTxt.text = string.Format("Mon Name : {0} \n HP : {1}", data.name, data.hp);
    }

    public Transform GetT()
    {
        return transform;
    }

    public void AddLog(string log)
    {
        logstr.Append(log);
        logstr.Append("\n");
        
        logText.text = logstr.ToString();
    }
}
