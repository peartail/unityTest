using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using System.Text;
using Data;

public class battleTestDlg : MonoBehaviour {

    public BattleTestStage stageInfo;

    public Text logText;
    public Text CharInfoTxt;
    public Text MonInfoTxt;

    private void Awake()
    {
        if(CharInfoTxt != null)
        {
            var baseData = stageInfo.MyCharData.baseData;
            SetMyCharaData(baseData, stageInfo.MyCharData.characterCur);
            stageInfo.MyCharData.characterCur.Ob.Subscribe(cp =>
            {
                SetMyCharaData(baseData, cp);
            });
        }

        if(MonInfoTxt != null)
        {
            var monBase = stageInfo.MonData.BaseData;
            SetMonsterData(monBase, stageInfo.MonData);
            stageInfo.MonData.Ob.Subscribe(data =>
            {
                SetMonsterData(monBase, data);
            });
        }

        if(logText != null)
        {
            stageInfo.logOb.SubscribeToText(logText);
        }
    }

    private void SetMyCharaData(CharacterBase cb,CharacterPhysical cp)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("CharacterName : {0} \n", cb.ClassName);
        builder.AppendFormat("HP : {0}/{1} \n", cp.HP, cb.HP);
        builder.AppendFormat("Energy : {0}/{1} \n", cp.Energy, cb.Energy);

        CharInfoTxt.text = builder.ToString();
    }

    private void SetMonsterData(MonsterBase mb,MonsterData md)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("MonsterName : {0} \n", mb.MonsterName);
        builder.AppendFormat("HP : {0}/{1} \n", md.HP.Value, mb.HP);

        MonInfoTxt.text = builder.ToString();
    }
}
