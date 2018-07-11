using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMono<T> : MonoBehaviour where T : class {
    protected static T instance = null;

    public static bool IsNull
    {
        get { return instance == null; }
    }

    public static T G
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("NullException Instance : " + typeof(T));
                return null;
            }
            return instance;
        }
    }
}
