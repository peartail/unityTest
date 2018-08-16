using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorObject : MonoBehaviour {

    FloorLoc<LocationEvent> currentFloor = null;
	// Use this for initialization
	void Start () {
		
	}
        
    public void SetFloorLoc(FloorLoc<LocationEvent> floor)
    {
        currentFloor = floor;
    }
}
