using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace DBUtil
{
    public class WrapperList<T> where T : struct
    {
        public List<T> data;
        public WrapperList(List<T> d)
        {
            data = d;
        }

    }
}


public class DBUtilCommon : MonoBehaviour {

	// Use this for initialization
}
