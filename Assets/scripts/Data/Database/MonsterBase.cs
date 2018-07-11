using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Monster
{
    [Serializable]
    public class MonsterBase
    {
        [SerializeField]
        private string monsterName;
        [SerializeField]
        private string prefabName;

        public MonsterBase(string mname,string prefname)
        {
            monsterName = mname;
            prefabName = prefname;
        }

        public JSONObject ToJson()
        {
            JSONObject obj = new JSONObject();
            obj.Add("monsterName", new JSONString(monsterName));
            obj.Add("prefabName", new JSONString(prefabName));

            return obj;
        }

        public static MonsterBase GetJson(JSONObject obj)
        {
            string cname = obj["monsterName"];
            string fname = obj["prefabName"];

            return new MonsterBase(cname, fname);
        }
    }


    public class MonsterBaseCollection
    {
        Dictionary<int, MonsterBase> monsterMap = null;
        private bool isUpdated = false;
        public MonsterBase Get(int index)
        {
            if (!isUpdated)
            {
                Load();
            }
            if (monsterMap.ContainsKey(index))
            {
                return monsterMap[index];
            }

            Debug.LogError("Not CharacterBase");
            return null;
        }

        private void Load()
        {
            string filedata = ExDataCtr.ETLoadData("Assets/Bundles/Data/CharacterBase");
            JSONObject node = JSON.Parse(filedata).AsObject;
            monsterMap = new Dictionary<int, MonsterBase>();
            var list = JsonToData(node).GetEnumerator();
            int count = 0;
            while (list.MoveNext())
            {
                var data = list.Current;
                monsterMap[count++] = data;
            }

            isUpdated = true;
        }

        #region EXTERNDATA

        public static string DataToJson(List<MonsterBase> characterList)
        {
            JSONObject node = new JSONObject();
            JSONArray arr = new JSONArray();
            var iter = characterList.GetEnumerator();
            while (iter.MoveNext())
            {
                arr.Add(iter.Current.ToJson());
            }

            node.Add("arr", arr);

            string jstring = node.ToString();
            return jstring;
        }

        public static List<MonsterBase> JsonToData(JSONObject obj)
        {
            List<MonsterBase> result = new List<MonsterBase>();
            JSONArray arr = obj.AsObject["arr"].AsArray;
            var iter = arr.GetEnumerator();
            while (iter.MoveNext())
            {
                JSONObject loopobj = iter.Current.Value.AsObject;
                MonsterBase item = MonsterBase.GetJson(loopobj);
                result.Add(item);
            }
            return result;
        }

        #endregion

    }


}

