using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;


[Serializable]
public struct ItemTouch : IComponentData
{
    public int Value;

}



public class ItemTouchComponent : ComponentDataWrapper<ItemTouch> {

}
