﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AssetBundleTeset : MonoBehaviour {


    [MenuItem("Bundles/Build AssetBundles")]
    static void BuildAllAssetBundles() {

         var result = BuildPipeline.BuildAssetBundles("Assets/Bundles/Data", BuildAssetBundleOptions.None, BuildTarget.Android);

    }

   
}
