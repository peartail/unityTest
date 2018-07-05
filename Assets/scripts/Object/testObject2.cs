using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class testObject2 : MonoBehaviour {
    DummyData dummyData = null;
    
    public Text txt;
	// Use this for initialization
	void Start () {
        dummyData = Data.DataWarehouse.G.GetDataRX<DummyData>();
        //dummyData.count.Subscribe(x =>
        //{
        //    txt.text = x.ToString();
        //});
        dummyData.count.DistinctUntilChanged().SubscribeToText<int>(txt);
        //using (var ctr = new DataCtr<DummyData>())
        //{
        //    dummyData = ctr.Get();

        //    dummyData.count.Subscribe(x =>
        //    {
        //        txt.text = x.ToString();
        //    });

        //}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
