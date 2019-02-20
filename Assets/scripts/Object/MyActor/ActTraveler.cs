using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DDatas;
using UniRx;

public class ActTraveler : MonoBehaviour {

    DataMyActor MyInfo;
	// Use this for initialization
	void Start () {
        MyInfo = DataMyActorBox.GetData(DataMyActorKind.Treveler);
	}

    private ReactiveProperty<int> curHp;
    private ReactiveProperty<int> curShield;


}
