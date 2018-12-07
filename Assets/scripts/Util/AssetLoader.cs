using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class AssetLoader : IDisposable
{
    bool disposed = false;
    private static readonly string rootPath = "Assets/Bundles/";
    private static Queue<UnityEngine.GameObject> cachePrefab;
    private static readonly int MaxCacheSize = 10;
	public T LoadAssetInstance<T>(string path) where T : UnityEngine.Object
    {

#if UNITY_EDITOR
        string relpath = Path.Combine(rootPath, path);
        T result = (T)UnityEditor.AssetDatabase.LoadAssetAtPath(relpath, typeof(T));
        return UnityEngine.Object.Instantiate(result);
#else
        return null;
#endif

    }

    public T Load<T>(string path) where T : UnityEngine.Object
    {

#if UNITY_EDITOR
        string relpath = Path.Combine(rootPath, path);
        Debug.Log("relpath : " + relpath);
        T result = (T)UnityEditor.AssetDatabase.LoadAssetAtPath(relpath, typeof(T));
        Debug.Log("result : " + result);
        return result;
#else
        return null;
#endif

    }

    private void SaveCacheAsset<T>(string path,T data) where T : UnityEngine.Object
    {

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
