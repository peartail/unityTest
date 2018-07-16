using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Data
{


    [Serializable]
    public class MonsterBase
    {
        [SerializeField]
        private string monsterName;
        [SerializeField]
        private string prefabName;
        [SerializeField]
        private int hp;
        [SerializeField]
        private int kind;

        public int HP { get { return hp; } }
        public string MonsterName { get { return monsterName; } }
        public int MonsterKind { get { return kind; } }
        public string MonsterPrefab {  get { return Path.Combine("Monster/", prefabName); } }
        public MonsterBase(string mname, string prefname, int hp, int kind)
        {
            monsterName = mname;
            prefabName = prefname;
            this.hp = hp;
            this.kind = kind;
        }

        public JSONObject ToJson()
        {
            JSONObject obj = new JSONObject();
            obj.Add("monsterName", new JSONString(monsterName));
            obj.Add("prefabName", new JSONString(prefabName));
            obj.Add("hp", new JSONNumber(hp));
            obj.Add("kind", new JSONNumber(kind));
            return obj;
        }

        public static MonsterBase GetJson(JSONObject obj)
        {
            string cname = obj["monsterName"];
            string fname = obj["prefabName"];
            int hp = obj["hp"].AsInt;
            int kind = obj["kind"].AsInt;

            return new MonsterBase(cname, fname, hp, kind);
        }
    }





    public class MonsterBaseCollection
    {
        public enum EMonsterType
        {
            Dummy1 = 0,
        }

        public enum EMonsterKind
        {
            Slime = 1,
        }


        Dictionary<int, MonsterBase> monsterMap = null;
        Dictionary<int, MonsterBase> monsterKindMap = null;
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

        public MonsterBase GetKind(int kind)
        {
            if (!isUpdated)
            {
                Load();
            }

            if (monsterKindMap.ContainsKey(kind))
            {
                return monsterKindMap[kind];
            }

            Debug.LogError("Not CharacterBase");
            return null;
        }

        private void Load()
        {
            string filedata = ExDataCtr.ETLoadData(MonsterBaseDB.filePath);
            JSONObject node = JSON.Parse(filedata).AsObject;
            monsterMap = new Dictionary<int, MonsterBase>();
            monsterKindMap = new Dictionary<int, MonsterBase>();
            var list = JsonToData(node).GetEnumerator();
            int count = 0;
            while (list.MoveNext())
            {
                var data = list.Current;
                monsterMap[count++] = data;
                monsterKindMap[data.MonsterKind] = data;
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
