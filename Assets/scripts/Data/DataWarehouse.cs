using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

using UniRx;


namespace Data
{
    
    public delegate void ChangeItem(IDataResource data);
    public class ChangeItemWrapper
    {

    }
    public interface IDataResource
    {
        string GetJsonData();
        void SetJsonData(JSONNode node);
        EDataPlace GetDataPlace();
        void OnChange(ChangeItem changeFunc);
    }

    public enum EDataPlace : int
    {
        File = 0,
    }

    public enum EDataResource : int
    {
        DummyData = 0,
    }

    
    public class DataWarehouse : SingleMono<DataWarehouse>
    {
        
        //private static DataWarehouse instance = null;
        private static bool isLoaded = false;
        private HashSet<IDataResource> dataMap = null;
        private List<IDataResource> pendingSaveList = null;
        private IDataResource cashData = null;
        //public delegate void OnDataLoadComplete<T>(bool success, T data);
        private string dataPath = "";
        //public static bool IsNull
        //{
        //    get { return instance == null; }
        //}

        //public static DataWarehouse G
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            Debug.LogError("NullException Instance : " + typeof(DataWarehouse));
        //            return null;
        //        }
        //        return instance;
        //    }
        //}

        void OnDestroy()
        {
            SavePendingData();
            Debug.Log("OnDestroy1");
        }

        private void Awake()
        {
            if (!isLoaded)
            {
                DontDestroyOnLoad(this);
                dataMap = new HashSet<IDataResource>();
                pendingSaveList = new List<IDataResource>();
                cashData = null;
                instance = this;
                isLoaded = true;
#if EXAMPLE_JSON
                dataPath = Path.Combine(@"C:\testFile\", "data");
#else
                dataPath = Path.Combine(Application.persistentDataPath, "data");
#endif
                Observable.TimerFrame(2000).Subscribe(_ =>
                {
                    SavePendingData();
                });
            }
        }

        private void OnChange<T>(T data) where T : IDataResource
        {
            int length = pendingSaveList.Count;
            for (int i = 0; i < length; i++)
            {
                if(pendingSaveList[i].ToString().Equals(data.ToString()))
                {
                    return;
                }
            }
            pendingSaveList.Add(data);
        }

        private void SavePendingData()
        {
            int length = pendingSaveList.Count;
            for (int i = 0; i < length; i++)
            {
                DataSave(pendingSaveList[i]);
            }
            pendingSaveList.Clear();
        }

        //실제 데이터는 아니고 RX용 데이터
        public T GetDataRX<T>() where T : class, IDataResource, new()
        {
            if(cashData != null && cashData.GetType() == typeof(T))
            {
                return (T)cashData;
            }

            var iter = dataMap.GetEnumerator();
            while(iter.MoveNext())
            {
                if(iter.Current.GetType() == typeof(T))
                {
                    cashData = iter.Current;
                    return (T)iter.Current;
                }
            }

            T data = new T();
            dataMap.Add(data);
            data.OnChange(OnChange);
            cashData = data;
            StartCoroutine(DataLoad<T>(data));

            return data;
        }

        private IEnumerator DataLoad<T>(T data) where T : IDataResource
        {
            string dataString = null;
            switch (data.GetDataPlace())
            {
                case EDataPlace.File:
                    {
                        dataString = FileDataLoad<T>(data);
                        break;
                    }
            }

            if(dataString != null)
            {
                JSONNode jnode = JSON.Parse(dataString);
                data.SetJsonData(jnode);
            }
            else
            {

                DataSave(data);
            }

            yield return null;
        }

        private void DataSave<T>(T data) where T : IDataResource
        {
            switch (data.GetDataPlace())
            {
                case EDataPlace.File:
                    {
                        FileDataSave(data);
                        break;
                    }
            }
        }


#region FILEIO

        private string FileDataLoad<T>(T data)
        {
            //string dataPath = Path.Combine(Application.persistentDataPath, "data");

            CheckDir();
            string filePath = Path.Combine(dataPath, data.ToString());
            if (File.Exists(filePath))
            {
                using (var fileStream = File.OpenRead(filePath))
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

        private void FileDataSave<T>(T data) where T : IDataResource
        {
            //string dataPath = Path.Combine(Application.persistentDataPath, "data");

            string dataString = data.GetJsonData();
            byte[] dataByte = Encoding.UTF8.GetBytes(dataString);
            int fileLength = dataByte.Length;
            string filePath = Path.Combine(dataPath, data.ToString());
            //if (File.Exists(filePath))
            //{
                using (StreamWriter fstream = File.CreateText(filePath))
                {
                    fstream.Write(dataString);
                    fstream.Close();
                }
            //}
            //else
            //{
            //    using (FileStream fstream = File.Create(filePath, fileLength))
            //    {
            //        fstream.Write(dataByte, 0, fileLength);
            //    }
            //}
        }

        private void CheckDir()
        {
            //string dataPath = Path.Combine(Application.persistentDataPath, "data");

            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }
        }
#endregion


    }

}
