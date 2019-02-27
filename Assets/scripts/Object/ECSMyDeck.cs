using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ECSMyDeck : MonoBehaviour {


}


public class ECSMyDescSystem : ComponentSystem
{
    struct Components
    {
        public ECSMyDeck myDesc;
    }


    protected override void OnUpdate()
    {
    }
}
