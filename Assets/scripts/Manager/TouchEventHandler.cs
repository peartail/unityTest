using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;
using UniRx.Triggers;
public class TouchEventHandler : MonoBehaviour {

    private Plane mainplane;
    public Camera touchCamera;
    enum MouseEvent
    {
        Down,
        Downing,
        Up,
        Release,
    }

    private Transform touchedItem = null;
    // Use this for initialization
    private void Awake()
    {
        mainplane = new Plane(Vector3.back, Vector3.zero);
    }
    void Start () {
        MouseStart();
    }

    struct HittedInfo
    {
        Transform hittedTrans;

    }
    private void MouseStart()
    {
        int layerMask = 1 << 8;
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Select(_ =>
            {
                Ray ray = touchCamera.ScreenPointToRay(Input.mousePosition);
                return Physics.RaycastAll(ray, 10000, layerMask);
            })
            .Subscribe(OnMouseItem);
    }
    private void OnMouseItem(RaycastHit[] hits)
    {
        int length = hits.Length;
        if(length > 0)
        {
            var touchedItem = hits[0].transform.gameObject.GetComponent<TouchMoveableItem>();
            touchedItem?.Clicked();


            var mouseUpEvent = Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonUp(0));

            Observable.EveryUpdate()
                .TakeUntil(mouseUpEvent)
                .Where(_ => Input.GetMouseButton(0))
                .Select(_ => hits[0].transform)
                .Subscribe(hit =>
                {
                    float dist = 0;
                    var ray = touchCamera.ScreenPointToRay(Input.mousePosition);
                    if(mainplane.Raycast(ray, out dist))
                    {
                        var pos = ray.GetPoint(dist);
                        touchedItem?.SetTouchPoint(pos);
                    }
                });

            Observable.EveryLateUpdate()
                .Where(_ => Input.GetMouseButtonUp(0))
                .Select(_ => hits[0])
                .Subscribe(x =>
                {
                    touchedItem?.Release();
                });
        }

    }
}
