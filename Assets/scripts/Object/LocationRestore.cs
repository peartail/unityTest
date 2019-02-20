﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationRestore : MonoBehaviour {

    Vector3 originposition;
    float velocity = 5;
    private static readonly float MIN_DISTANCE = 0.3f;
    private float startTime;
    private float distance;
	// Use this for initialization
	void Start () {
        originposition = transform.position ;
	}


    public void MoveRelease()
    {
        startTime = Time.time;
        distance = Vector3.Distance(transform.position, originposition);
        StartCoroutine(MoveOriginPos());
    }


    private IEnumerator MoveOriginPos()
    {
        while(true)
        {
            float distCovered = (Time.time - startTime) * velocity;
            float fract = distCovered / distance;

            var curPos = transform.position;

            var result = Vector3.Lerp(curPos, originposition, fract);
            if(!float.IsNaN(result.x) && !float.IsNaN(result.x) && !float.IsNaN(result.x))
            {
                transform.position = result;
            }

            var dist = Vector3.Distance(curPos, originposition);
            if (dist < MIN_DISTANCE)
            {
                transform.position = originposition;
                yield break;
            }


            yield return null;
        }
    }

}
