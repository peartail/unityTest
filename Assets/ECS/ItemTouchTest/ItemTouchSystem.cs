using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Jobs;



class ItemTouchSystem : ComponentSystem
{
    bool isMouseDowned = false;
    bool isMouseUp = true;
    protected override void OnUpdate()
    {


            //}
            //if (Input.GetMouseButtonDown(0))
            //{
            //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    var hits = Physics.RaycastAll(ray);
            //    int size = hits.Length;
            //    for (int i = 0; i < size; i++)
            //    {
            //        Debug.Log("LOG TET" + hits[i].transform.name);
            //        foreach (var entity in GetEntities<testImageGroup>())
            //        {
            //            //Debug.Log("LOG TET" + entity.trans.name);
            //            //if (entity.trans.name == hits[i].transform.name)
            //            //{
            //            //    Debug.Log("LOG TET" + hits[i].transform.name);
            //            //}
            //        }
            //    }
            //}



    }
}
