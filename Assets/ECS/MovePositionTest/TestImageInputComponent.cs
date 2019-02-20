using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms2D;
using UnityEngine;



[Serializable]
public struct TestImageInput : IComponentData
{
    public int position;
}

public class TestImageInputComponent : ComponentDataWrapper<TestImageInput>
{ }
