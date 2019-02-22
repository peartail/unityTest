using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleStage : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        SettingActor();
    }


    private ActTraveler actor = null;
    private Monster1 mon = null;

    public void SettingActor()
    {
        actor = ObjectLoadMgr.LoadAsset<ActTraveler>("ActTraveler");
        actor?.transform.SetParent(transform);
        actor?.Init();


        mon = ObjectLoadMgr.LoadAsset<Monster1>("Monster/Monster1");
        mon?.transform.SetParent(transform);
        mon?.Init();
    }

    public ActTraveler GetMyActor { get { return actor; } }
    public Monster1 GetMonster { get { return mon; } }

}
