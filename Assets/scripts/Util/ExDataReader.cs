using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ExDataReader : MonoBehaviour {
    public enum EReaderType
    {
        File,
        HTTP,
    }

    private static ExDataReader instance = null;

    public static ExDataReader G
    {
        get
        {
            if(instance == null)
            {
                return null;
            }

            return instance;
        }
    }
    

    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }


    #region LOAD
    public string GetData(string filepath,EReaderType type = EReaderType.File)
    {
        switch (type)
        {
            case EReaderType.File:
                return GetFileData(filepath);
            case EReaderType.HTTP:
                return GetHTTPData(filepath);
        }

        return null;
    }

   

    public delegate void OnCompleteGetData(string data);
    public void GetDataAsync(string filepath, OnCompleteGetData compFunc, EReaderType type = EReaderType.File)
    {
        StartCoroutine(GetDataCoroutine(filepath,compFunc,type));
    }

    public IEnumerator GetDataCoroutine(string filepath, OnCompleteGetData compFunc, EReaderType type = EReaderType.File)
    {
        string result = null;
        switch (type)
        {
            case EReaderType.File:
                result = GetFileData(filepath);
                break;
            case EReaderType.HTTP:
                result = GetHTTPData(filepath);
                break;
        }

        if(result != null)
        {
            compFunc(result);
        }

        yield return null;
    }

    private string GetFileData(string filepath)
    {
        if(File.Exists(filepath))
        {
            using (var fileStream = File.OpenRead(filepath))
            {
                int fileLength = (int)fileStream.Length;
                byte[] fileData = new byte[fileLength];
                fileStream.Read(fileData, 0, fileLength);
                string fileString = Encoding.UTF8.GetString(fileData, 0, fileLength);
                fileStream.Close();
                return fileString;
            }
        }

        return null;
    }

    private string GetHTTPData(string webpath)
    {
        return null;
    }

    #endregion


    #region SAVE

    public void SaveData(string filePath, EReaderType type = EReaderType.File)
    {

    }

    #endregion
}
