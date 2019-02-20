using System.Collections;
using System.Collections.Generic;

namespace DDatas
{
    public enum DataMonsterKind
    {
        Monster1 = 0,
    }

    public struct DataMonsterSkillInfo
    {
        enum SkillType
        {
            Attack,
            Defend,
        }


        private int skillCastingTime;
        private string skillName;
        private SkillType type;
    }


    public struct DataMonster
    {
        public int id;
        public string monName;
        public string monDesc;
        public int hp;
        public int maxHp;
        public int InitHP { set { hp = maxHp = value; } }
        public List<DataMonsterSkillInfo> skills;
    }


    public class DataMonsterBox
    {
        private bool isLoaded = false;
        private List<DataMonster> monsterDatas = null;
        private static DataMonsterBox i = null;
        private static DataMonsterBox I
        {
            get
            {
                if (i == null)
                {
                    i = new DataMonsterBox();
                }
                return i;
            }

        }

        void InitMonster()
        {
            monsterDatas = new List<DataMonster>();
            monsterDatas.Add(new DataMonster() { id = (int)DataMonsterKind.Monster1, monName = "Monster1", monDesc = "Monster1", InitHP = 100 });
            isLoaded = true;
        }

        public DataMonster GetD(int idx)
        {
            if (!isLoaded)
            {
                InitMonster();
            }
            var item = monsterDatas.Find(x => x.id == idx);
            return item;
        }

        public static DataMonster GetData(int id)
        {
            return I.GetD(id);
        }

        public static DataMonster GetData(DataMonsterKind id)
        {
            return I.GetD((int)id);
        }

    }

}
