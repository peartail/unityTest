using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStateManager : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
