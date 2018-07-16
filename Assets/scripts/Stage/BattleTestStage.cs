using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using System.Text;

public class BattleTestStage : MonoBehaviour {

    enum ETurnType
    {
        PrepareMyTurn,
        MyTurn,
        PrepareYourTurn,
        YourTurn,
        EndStage,
    }


    private CharacterData myCharData = null;
    private MonsterData monData = null;
    public CharacterData MyCharData {  get { return myCharData; } }
    public MonsterData MonData { get { return monData; } }

    #region Event
    Subject<string> logSubject = new Subject<string>();
    public IObservable<string> logOb { get { return logSubject.AsObservable(); } }

    #endregion

    StringBuilder LogText = new StringBuilder();
    bool IsBattlePrepared = false;
	// Use this for initialization
	void Awake () {
        DataBox box = null;

        using (var data = new WarehouseManager())
        {
            data.NewWareHouse();
            box = data.CurrentBox;
            if(box != null)
            {
                myCharData = box.GetDataRX<CharacterData>();
                monData = box.GetDataRX<MonsterData>();

                using (AssetLoader loader = new AssetLoader())
                {
                    var obj = loader.LoadAsset<UnityEngine.Object>(monData.BaseData.MonsterPrefab);
                    var monPrefab = (GameObject)GameObject.Instantiate(obj);
                    monPrefab.transform.SetParent(transform, false);
                }
            }

            IsBattlePrepared = true;
        }
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
