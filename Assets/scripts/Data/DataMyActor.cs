using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDatas
{
    public enum DataMyActorKind
    {
        Treveler = 0,
    }

    public struct DataMyActor
    {
        public int kind;
        public string Actorname;
        public int Hp;
        public int MaxHp;

        public int Shield;

        public int Attack;
        public int Defend;
        public int Speed;
    }



    public class DataMyActorBox
    {
        private static DataMyActorBox i = null;

        private static DataMyActorBox I
        {
            get
            {
                if (i == null)
                {
                    i = new DataMyActorBox();
                }
                return i;
            }
        }

        public static DataMyActor GetData(DataMyActorKind kind)
        {
            return I.getD((int)kind);
        }

        public static DataMyActor GetData(int kind)
        {
            return I.getD(kind);
        }


        private List<DataMyActor> datas = null;
        private bool isLoaded = false;
        private void InitData()
        {
            isLoaded = true;

            datas = new List<DataMyActor>();
            AddTestData();
        }

        private void AddTestData()
        {
            datas.Add(new DataMyActor() { kind = (int)DataMyActorKind.Treveler, Actorname = "Treverer", Hp = 80, MaxHp = 80, Attack = 0, Defend = 0, Speed = 0 });
        }

        private DataMyActor getD(int kind)
        {
            if (!isLoaded)
            {
                InitData();
            }

            return datas.Find(x => x.kind == kind);
        }
    }

}
