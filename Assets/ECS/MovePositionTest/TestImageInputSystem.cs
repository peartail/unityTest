using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class TestImageInputSystem : JobComponentSystem
{
    private bool onClicked = false;
    private bool onReleased = true;


    [BurstCompile]
    struct testInputJob : IJobProcessComponentData<TestImageInput>
    {
        public int input;
        public void Execute(ref TestImageInput data)
        {
            data.position = input;

        }
    }

    enum MouseState
    {
        Release,
        Down,
        Up,
    }

    private MouseState curMstate = MouseState.Release;

    private int inputCount = 0;
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        //curMstate = CheckButton();
        //Debug.Log(curMstate);

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit[] hits = Physics.RaycastAll(ray, 10000);


        var job = new testInputJob {
            input = inputCount++,
        };

        return job.Schedule(this, 1, inputDeps);
    }

    private MouseState CheckButton()
    {
        if (Input.GetMouseButton(0))
        {
            return MouseState.Down;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            return MouseState.Up;
        }
        else
        {
            return MouseState.Release;
        }

    }
}
