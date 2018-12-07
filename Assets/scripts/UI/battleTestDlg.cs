using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;
using System.Text;
using System;

public class battleTestDlg : MonoBehaviour,CUI {

    public BattleTestStage stageInfo;

    public Text logText;
    public Text CharInfoTxt;
    public Text MonInfoTxt;
    public Button atBtn;
    public Button turnEnd;
    private void Awake()
    {

    }

    public Transform GetT()
    {
        return transform;
    }
}
