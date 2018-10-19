using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutineTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    IEnumerator FirstLoad()
    {
        Debug.Log("First");

        yield return StartCoroutine(SecondLoad());

        Debug.Log("Third");
    }

    IEnumerator SecondLoad()
    {
        for(int i=0;i<100;i++)
        {
            yield return null;
        }
        Debug.Log("Second");
    }


}
