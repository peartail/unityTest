using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class TargetingItem : MonoBehaviour {

    internal void CheckItemEntered(Transform itemTrans)
    {

    }
}

public class TargetingItemSystem : ComponentSystem
{
    struct Components
    {
        public TargetingItem item;
        public Transform trans;
        public TouchMoveableItem movable;
    }

    protected override void OnUpdate()
    {
        foreach(var entity in GetEntities<Components>())
        {
            if(entity.movable.isClicked)
            {
                var itemTrans = entity.trans;

                Vector3 raypos = itemTrans.position;
                raypos.z = 0;
                Ray ray = new Ray(raypos, Vector3.forward);
                int layerMask = 1 << 9;
                RaycastHit[] lists = Physics.RaycastAll(ray, 100, layerMask);
                if (lists.Length > 0)
                {
                    //itemTrans.localScale = new Vector3(0.5f, 0.5f);
                    Vector3 myloc = itemTrans.localPosition;
                    myloc.z = 5;
                    itemTrans.localPosition = myloc;
                }
                else
                {
                    Vector3 myloc = itemTrans.localPosition;
                    myloc.z = 0;
                    itemTrans.localPosition = myloc;
                }
            }
        }
    }
}
