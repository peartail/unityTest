using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;




public class DataLoader : IDisposable
{

    bool disposed = false;
    private static readonly string rootPath = "Assets/Bundles/Data";

    public T LoadData<T>(string path) where T : UnityEngine.Object
    {
        //File.Exists(rootPath)

        return null;

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
