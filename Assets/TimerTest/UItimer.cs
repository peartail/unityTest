using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItimer : MonoBehaviour {
    Button btnTimer = null;
	// Use this for initialization
	void Start () {
        if(btnTimer != null)
        {
            btnTimer.onClick.AddListener(OnClickTimerStart);
        }		
	}
	

    void OnClickTimerStart()
    {

    }
	
}
