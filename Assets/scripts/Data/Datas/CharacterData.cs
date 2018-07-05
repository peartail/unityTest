using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

using UniRx;
public class CharacterPhysical
{
    
    private int hp;
    private int energy;
    private Subject<CharacterPhysical> sub;
    public IObservable<CharacterPhysical> Ob
    {
        get
        {
            return sub.AsObservable();
        }
    }
    public int HP
    {
        get { return hp; }
        set
        {
            if (hp != value)
            {
                sub.OnNext(this);
            }
            hp = value;
        }

    }
    public int Energy
    {
        get { return energy; }
        set
        {
            if (energy != value)
            {
                sub.OnNext(this);
            }
            energy = value;
        }
    }
    internal CharacterPhysical()
    {
        sub = new Subject<CharacterPhysical>();
    }

    internal JSONObject GetJNode()
    {
        JSONObject obj = new JSONObject();
        JSONNumber hp = new JSONNumber(this.hp);
        JSONNumber energy = new JSONNumber(this.energy);
        obj.Add("HP", hp);
        obj.Add("Energy", energy);

        return obj;
    }

    internal void SetJNode(JSONObject obj)
    {
        if (obj != null)
        {
            this.hp = obj["HP"].AsInt;
            this.energy = obj["Energy"].AsInt;
        }

    }


}

public class CharacterData : IDataResource
{
    public CharacterPhysical characterCur = null;
    ChangeItem onChange = null;
    public CharacterData()
    {
        
        characterCur = new CharacterPhysical();
        characterCur.Ob.Subscribe(x =>
        {
            if(onChange != null)
            {
                onChange(this);
            }
        });
    }
    public EDataPlace GetDataPlace()
    {
        return EDataPlace.File;
    }

    

    public string GetJsonData()
    {
        JSONObject root = new JSONObject();
        JSONObject cc = characterCur.GetJNode();
        root.Add("CharacterBase", cb);
        root.Add("CharacterCur", cc);

        return root.ToString();
    }

    public void OnChange(ChangeItem changeFunc)
    {
        onChange = changeFunc;


    }

    public void SetJsonData(JSONNode node)
    {
        JSONObject root = node.AsObject;
        characterCur.SetJNode(root["CharacterCur"].AsObject);
    }

    public override string ToString()
    {
        return "CharacterData";
    }
}
