using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UniRx;
using UnityEngine;

namespace Data
{


    public interface IDataResource
    {
        JSONNode GetJsonData();
        void SetJsonData(JSONNode node);
    }
    public class DataBox
    {
        private string dataName;
        private HashSet<IDataResource> dataSet = null;
        private IDataResource cashData = null;
        public string DataName { get { return dataName; } }

        public DataBox(string dataName)
        {
            this.dataName = dataName;
            dataSet = new HashSet<IDataResource>();
            cashData = null;
        }

        public bool Add<T>(T data) where T : class, IDataResource
        {
            if(dataSet.Contains(data))
            {
                return false;
            }

            dataSet.Add(data);
            return true;
        }

        public T GetDataRX<T>() where T : class, IDataResource
        {
            if (cashData != null && cashData.GetType() == typeof(T))
            {
                return (T)cashData;
            }

            var iter = dataSet.GetEnumerator();
            while (iter.MoveNext())
            {
                if (iter.Current.GetType() == typeof(T))
                {
                    cashData = iter.Current;
                    return (T)iter.Current;
                }
            }

            return null;
        }

        public JSONNode GetJson()
        {
            JSONObject obj = new JSONObject();
            var iter = dataSet.GetEnumerator();
            while(iter.MoveNext())
            {
                obj.Add(iter.Current.ToString(), iter.Current.GetJsonData());
            }

            return obj;
        }

        public void SetJson(JSONNode root)
        {
            JSONObject obj = root.AsObject;
            var iter = dataSet.GetEnumerator();
            while (iter.MoveNext())
            {
                var item = obj[iter.Current.ToString()];
                if(item != null)
                {
                    iter.Current.SetJsonData(item);
                }
            }
        }

    }

    public class DataWarehouse : SingleMono<DataWarehouse>
    {

        private static bool isLoaded = false;
        private DataBox currentbox = null;
        private HashSet<DataBox> boxList = null;
        private string dataPath = "";

        void OnDestroy()
        {
            Debug.Log("OnDestroy1");
        }

        private void Init()
        {
            DontDestroyOnLoad(this);
            instance = this;
        }

        private void Awake()
        {
            if (!isLoaded)
            {
                Init();
                dataPath = Path.Combine(Application.persistentDataPath, "data");
                isLoaded = true;
            }
        }



        public void SaveFullData()
        {

        }

        public void LoadFullData(string name = null)
        {
            string gameData = null;
            if(name == null)
            {
                var fileArr = Directory.GetFiles(dataPath);
                Array.Sort(fileArr, (x, y) =>
                {
                    return new CaseInsensitiveComparer().Compare(y, x);
                });

                if(fileArr.Length <= 0)
                {
                    //Load Error
                    return;
                }

                gameData = ExDataCtr.GetFileData(Path.Combine(dataPath, fileArr[0]));

            }
            else
            {
                gameData = ExDataCtr.GetFileData(Path.Combine(dataPath, name));
            }

            if(gameData != null)
            {
                //Set Data
            }
        }

        internal void SetCurrentBox(DataBox box)
        {
            currentbox = box;
        }

        internal DataBox GetCurrentBox()
        {
            return currentbox;
        }
    }


}
