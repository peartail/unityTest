using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using Data;

public sealed class testObject : MonoBehaviour {
    DummyData dummyData = null;
    // Use this for initialization
    int v = 0;
    void Start () {
        dummyData = DataWarehouse.G.GetDataRX<DummyData>();
        v = dummyData.count.Value;
        //using (var ctr = new DataCtr<DummyData>())
        //{
        //    dummyData = ctr.Get();
        //}
    }

    public void OnClick()
    {
        dummyData.count.SetValueAndForceNotify(++v);
        //using (var ctr = new DataCtr<DummyData>())
        //{
        //    ctr.Set(x =>
        //    {
        //        x.count.SetValueAndForceNotify(v++);
        //    });
        //}

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
