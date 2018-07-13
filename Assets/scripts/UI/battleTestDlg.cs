using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using System.Text;

public class battleTestDlg : MonoBehaviour {

    public BattleTestStage stageInfo;

    Text logText;
    public Text CharInfoTxt;

    private void Start()
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
    }

    private void SetMyCharaData(CharacterBase cb,CharacterPhysical cp)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("CharacterName : {0} \n", cb.ClassName);
        builder.AppendFormat("HP : {0}/{1} \n", cp.HP, cb.HP);
        builder.AppendFormat("Energy : {0}/{1} \n", cp.Energy, cb.Energy);

        CharInfoTxt.text = builder.ToString();
    }
}
