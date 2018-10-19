using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LocationEvent
{
    public enum LocType : int
    {
        Monster = 0,
        Chest,
        Event,
    }
    public LocType currentType;
    public int index;
    public LocationEvent(int i,LocType lt)
    {
        currentType = lt;
        index = i;
    }

}


public class testLocCreater : MonoBehaviour {
    public Transform root;
    public GameObject item;
    public FloorObject obj;
	// Use this for initialization
	void Start () {
    }

	// Update is called once per frame
	void Update () {

	}
}
