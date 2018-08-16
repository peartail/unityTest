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

        var map = FloorMap<LocationEvent>.CreateFloorMap();
        List<LocationEvent> list = new List<LocationEvent>();

        int cnt = map.GetFullEventCount();
        for(int i=0;i<cnt;i++)
        {
            var locType = (LocationEvent.LocType)Random.Range(0, 2);
            var locInfo = new LocationEvent(i, locType);
            list.Add(locInfo);
        }

        map.Setting(list);
        var iter = map.GetFloorIter();
        while(iter.MoveNext())
        {
            var child = GameObject.Instantiate(obj.gameObject);
            var fo = obj.GetComponent<FloorObject>();
            fo.SetFloorLoc(iter.Current);
            child.transform.SetParent(root, false);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
