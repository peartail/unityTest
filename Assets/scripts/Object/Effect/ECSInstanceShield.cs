using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ECSInstanceShield : MonoBehaviour {


}


public class ECSInstanceShieldSystem : ComponentSystem
{
    struct Components
    {
        public ECSInstanceShield Instanceshield;
    }

    protected override void OnUpdate()
    {

    }
}

