using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class testActorInfo : MonoBehaviour {
    public testInitializer initailzer;
    public Text txtInfo;
	// Use this for initialization
	void Start () {
        if(initailzer.isInitailize.Value == false)
        {
            initailzer.isInitailize.Where(x => x == true)
            .Last()
            .Subscribe(_ =>
            {
                InitText();
            });
        }
        else
        {
            InitText();
        }
	}


    private void InitText()
    {

    }

}
