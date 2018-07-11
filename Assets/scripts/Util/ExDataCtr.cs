using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ExDataCtr : MonoBehaviour {
    public enum EReaderType
    {
        File,
        HTTP,
    }

    private static ExDataCtr instance = null;

    public static ExDataCtr G
    {
        get
        {
            if (instance == null)
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
    //public string GetData(string filepath)
    //{
    //    return GetFileData(filepath);
    //}



    public delegate void OnCompleteGetData(string data);
    public void GetDataAsync(string filepath, OnCompleteGetData compFunc, EReaderType type = EReaderType.File)
    {
        StartCoroutine(GetDataCoroutine(filepath, compFunc, type));
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

        if (result != null)
        {
            compFunc(result);
        }

        yield return null;
    }

    public static string GetFileData(string filepath)
    {
        if (File.Exists(filepath))
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

    public static string ETLoadData(string path)
    {
        return GetFileData(path);
    }

    #endregion


    #region SAVE

    public bool SaveData(string filePath,string data,  EReaderType type = EReaderType.File)
    {
        switch (type)
        {
            case EReaderType.File:
                SaveFileData(filePath,data);
                break;
        }

        return true;
    }

    private static bool SaveFileData(string filepath,string data)
    {
        File.WriteAllText(filepath, data);
        return false;
    }

    public static bool ETSaveData(string path,string data)
    {
        return SaveFileData(path, data);
    }

    #endregion
}
