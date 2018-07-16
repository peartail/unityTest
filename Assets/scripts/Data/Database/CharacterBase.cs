using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Data
{


    [Serializable]
    public class CharacterBase
    {
        [SerializeField]
        private string className;
        [SerializeField]
        private int hp;
        [SerializeField]
        private int energy;

        public string ClassName { get { return className; } }
        public int HP { get { return hp; } }
        public int Energy { get { return energy; } }
        public CharacterBase(string className, int hp, int energy)
        {
            this.className = className;
            this.hp = hp;
            this.energy = energy;
        }

        public JSONObject ToJson()
        {
            JSONObject obj = new JSONObject();
            obj.Add("classname", new JSONString(className));
            obj.Add("hp", new JSONNumber(hp));
            obj.Add("energy", new JSONNumber(energy));

            return obj;
        }

        public static CharacterBase GetJson(JSONObject obj)
        {
            string cname = obj["classname"];
            int hp = obj["hp"].AsInt;
            int energy = obj["energy"].AsInt;

            return new CharacterBase(cname, hp, energy);
        }

    }

    public class CharacterBaseCollection
    {
        public enum ECharacterType : int
        {
            Warrior = 0,
            Mage = 1,
        }

        private Dictionary<int, CharacterBase> characterMap = null;
        private bool isUpdated = false;
        public CharacterBase Get(ECharacterType index)
        {
            if (!isUpdated)
            {
                Load();
            }
            if (characterMap.ContainsKey((int)index))
            {
                return characterMap[(int)index];
            }

            Debug.LogError("Not CharacterBase");
            return null;
        }

        public void GetAsync(int index, Action<CharacterBase> result)
        {

        }

        private void Load()
        {
            string filedata = ExDataCtr.ETLoadData(CharacterBaseDB.filePath);
            if (filedata != null)
            {
                JSONObject node = JSON.Parse(filedata).AsObject;
                characterMap = new Dictionary<int, CharacterBase>();
                var list = JsonToData(node).GetEnumerator();
                int count = 0;
                while (list.MoveNext())
                {
                    var data = list.Current;
                    characterMap[count++] = data;
                }

                isUpdated = true;
            }
            else
            {
                Debug.LogError("No FileData! " + filedata);
            }

        }

        #region EXTERNDATA

        public static string DataToJson(List<CharacterBase> characterList)
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

        public static List<CharacterBase> JsonToData(JSONObject obj)
        {
            List<CharacterBase> result = new List<CharacterBase>();
            JSONArray arr = obj.AsObject["arr"].AsArray;
            var iter = arr.GetEnumerator();
            while (iter.MoveNext())
            {
                JSONObject loopobj = iter.Current.Value.AsObject;
                CharacterBase item = CharacterBase.GetJson(loopobj);
                result.Add(item);
            }
            return result;
        }

        #endregion

    }

}

