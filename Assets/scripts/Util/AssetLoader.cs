using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class AssetLoader : IDisposable
{
    bool disposed = false;
    private static readonly string rootPath = "Assets/Bundles/";
	public T LoadAsset<T>(string path) where T : UnityEngine.Object
    {
#if UNITY_EDITOR
        string relpath = Path.Combine(rootPath, path);
        return UnityEditor.AssetDatabase.LoadAssetAtPath<T>(relpath);
#else
        return null;
#endif

    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
        }

        disposed = true;
    }
}
