using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BSLine
{
    public enum Direction
    {
        Vertical,
        Horizontal,
    }

    public int offset;
}


public class BSpace
{
    BSLine line;
    BSpace fSpace;
    BSpace sSpace;
    int size;

    private BSpace()
    {

    }

    public static BSpace NewBSPace(int size)
    {
        BSpace space = new BSpace();
        space.size = size;
        return space;
    }

}
