using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DDatas;
using UnityEngine.UI;
using UniRx;

public class uiTestActor : MonoBehaviour {

    public Text txtMyActHP;
    public Text txtMyActName;
    public Text txtMonHP;
    public Text txtMonName;

    public battleStage stage;

    // Use this for initialization
    void Start () {
        BindObject();
	}

    public void BindObject()
    {
        actor = stage.GetMyActor;
        mon = stage.GetMonster;
        actorHelthCtr = actor.healthCtr;
        monHelthCtr = mon.healthCtr;

        actor?.InfoOb.Subscribe(SetMyActorText);
        mon?.GetOb.Subscribe(SetMonText);
    }

    private ActTraveler actor = null;
    private Monster1 mon = null;
    private HealthCtr actorHelthCtr = null;
    private HealthCtr monHelthCtr = null;

    private void SetMyActorText(DataMyActor act)
    {
        if(act.Shield > 0)
        {
            txtMyActHP.text = string.Format("{0}/{1} + {2}", act.Hp, act.MaxHp, act.Shield);
        }
        else
        {
            txtMyActHP.text = string.Format("{0}/{1}", act.Hp, act.MaxHp);
        }

        txtMyActName.text = act.Actorname;
    }

    private void SetMonText(DataMonster mon)
    {
        if (mon.Shield > 0)
        {
            txtMonHP.text = string.Format("{0}/{1} + {2}", mon.hp, mon.maxHp, mon.Shield);
        }
        else
        {
            txtMonHP.text = string.Format("{0}/{1}", mon.hp, mon.maxHp);
        }


        txtMonName.text = mon.monName;
    }

    public void AddPosion()
    {
        using (NormalAttackHelper helper = new NormalAttackHelper(actorHelthCtr))
        {
            helper.PoisonAttack(3, 5);
        }
    }

    public void AddFire()
    {
        using (NormalAttackHelper helper = new NormalAttackHelper(actorHelthCtr))
        {
            helper.FireAttack(3, 5);
        }
    }

    public void MyAttack()
    {
        using (NormalAttackHelper helper = new NormalAttackHelper(monHelthCtr))
        {
            helper.NormalAttack(15);
        }

    }


    public void MonAttack()
    {
        using (NormalAttackHelper helper = new NormalAttackHelper(actorHelthCtr))
        {
            helper.NormalAttack(10);
        }
    }

    public void PutShield()
    {
        actorHelthCtr?.AddShield(7);
    }

}
