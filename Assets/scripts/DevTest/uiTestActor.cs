using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DDatas;
using UnityEngine.UI;

public class uiTestActor : MonoBehaviour {

    public Transform parentTransform;
    public Text txtMyActHP;
    public Text txtMyActName;
    public Text txtMonHP;
    public Text txtMonName;
    // Use this for initialization
    void Start () {

	}

    ActTraveler actor = null;
    Monster1 mon = null;
    public void SettingActor()
    {
        var actor = ObjectLoadMgr.LoadAsset<ActTraveler>("ActTraveler");
        actor.transform.SetParent(parentTransform);

        mon = ObjectLoadMgr.LoadAsset<Monster1>("Monster/Monster1");
        mon.transform.SetParent(parentTransform);
        //mon = DataMonsterBox.GetData(DataMonsterKind.Monster1);

        //txtMyActHP.text = string.Format("{0}/{1}", actor.Hp,actor.MaxHp);
        //txtMyActName.text = actor.Actorname;

        //txtMonHP.text = string.Format("{0}/{1}", mon.hp, mon.maxHp);
        //txtMonName.text = mon.monName;
    }

    public void MyAttack()
    {

    }

    public void MonAttack()
    {

    }

    public void PutShield()
    {

    }
}
