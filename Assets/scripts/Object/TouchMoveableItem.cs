using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class TouchMoveableItem : MonoBehaviour {
    internal bool isClicked = false;
    internal bool isReleased = false;
    public void Clicked()
    {
        isClicked = true;
        touchPoint = transform.position;
    }
    public void Release() { isReleased = true; isClicked = false; }
    public Vector3 touchPoint;

    public void Awake()
    {
    }

    public void SetTouchPoint(Vector3 point)
    {
        touchPoint = point;
    }


}

public class TouchMoveableItemSystem : ComponentSystem
{
    struct Components
    {
        public TouchMoveableItem item;
        public Transform trans;
        public LocationRestore restore;
    }

    protected override void OnUpdate()
    {
        foreach(var entity in GetEntities<Components>())
        {
            if(entity.item.isClicked)
            {
                entity.trans.position = new Vector3(entity.item.touchPoint.x, entity.item.touchPoint.y, entity.trans.position.z);
            }

            if(entity.item.isReleased)
            {
                entity.item.isReleased = false;
                entity.restore.MoveRelease();
            }

            if(entity.restore.IsRestoring)
            {
                entity.restore.MoveOriginPos(Time.deltaTime);
            }
        }
    }


}

