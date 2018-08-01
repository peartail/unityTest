using System.Collections;
using System.Collections.Generic;
using UnityEngine;


internal class BSLine
{
    public enum Direction
    {
        Vertical,
        Horizontal,
    }
    internal Direction direction;
    internal int offset;
}


public class BSpace
{
    BSLine line;
    BSpace fSpace;
    BSpace sSpace;
    int width;
    int height;

    private BSpace(int w,int h)
    {
        width = w;
        height = h;
    }

    private void Split(BSLine.Direction dir)
    {
        line = new BSLine();
        line.direction = dir;
        int margin = 0;

        if(dir == BSLine.Direction.Horizontal)
        {
            margin = height;
        }
        else
        {
            margin = width;
        }

        
        
    }

    private void AddDimen()
    {

    }

    public static BSpace NewBSPace(int w,int h)
    {
        BSpace space = new BSpace(w,h);
        
        return space;
    }

}
