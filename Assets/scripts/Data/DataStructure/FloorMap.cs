using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloorLoc<T>
{
    internal enum AddState
    {
        OK,
        Full,
        Over,
    }
    internal static readonly int CeventCount = 3;
    T[] events;

    internal FloorLoc()
    {
        events = new T[CeventCount];
    }

    internal AddState AddItem(int index,T item)
    {
        if (index >= CeventCount)
            return AddState.Over;

        events[index] = item;
        if(index == CeventCount - 1)
        {
            return AddState.Full;
        }
        return AddState.OK;
    }

}

public class FloorMap<T> {
    private static readonly int floorCount = 10;
    private HashSet<FloorLoc<T>> floors;
    FloorMap()
    {
        floors = new HashSet<FloorLoc<T>>();
    }

    //false : Setting Fail
    public bool Setting(List<T> mapData)
    {
        int cnt = mapData.Count;
        FloorLoc<T> loc = new FloorLoc<T>();
        int locIndex = 0;
        int floorIndex = 0;
        for (int i =0;i<cnt; i++)
        {
            int range = Random.Range(0, mapData.Count);
            T result = mapData[range];
            switch (loc.AddItem(locIndex, result))
            {
                case FloorLoc<T>.AddState.OK:
                    locIndex++;
                    break;
                case FloorLoc<T>.AddState.Full:
                    locIndex = 0;
                    floors.Add(loc);
                    floorIndex++;
                    loc = new FloorLoc<T>();
                    break;
                case FloorLoc<T>.AddState.Over:
                    return false;
            }
            mapData.Remove(result);
        }
        return true;
    }

    public HashSet<FloorLoc<T>>.Enumerator GetFloorIter()
    {
        return floors.GetEnumerator();
    }


    public int GetFullEventCount()
    {
        return floorCount * FloorLoc<T>.CeventCount;
    }

    public static FloorMap<T> CreateFloorMap()
    {
        FloorMap<T> map = new FloorMap<T>();
        return map;
    }
}
