using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DDatas
{
    //행동타입?
    enum CardActionType
    {
        Attack, //공격 행동
        Defend, //방어 행동
        Item,   //아이템 사용
    }

    public struct DataActCard
    {
        public int index;
        public string CardName;
        public string CardDesc;

        public string Cardprefab;

        public int value;
        public int cost;
        public int duration;
    }


    public class DataActCardBox
    {
        private bool isLoaded = false;
        private List<DataActCard> cardDatas = null;
        private static DataActCardBox i = null;
        private static DataActCardBox I
        {
            get
            {
                if (i == null)
                {
                    i = new DataActCardBox();
                }
                return i;
            }

        }

        void InitCard()
        {
            int count = 0;
            cardDatas = new List<DataActCard>();
            var card = new DataActCard() { index = count++, CardName = "TestAttack" , CardDesc = "Test", cost = 2, duration = 5, value = 3 };
            cardDatas.Add(card);
            card = new DataActCard() { index = count++, CardName = "TestPoison", CardDesc = "Test", cost = 2, duration = 5, value = 3 };
            cardDatas.Add(card);
            card = new DataActCard() { index = count++, CardName = "TestShield", CardDesc = "Test", cost = 2, duration = 5, value = 3 };
            cardDatas.Add(card);
            isLoaded = true;
        }

        public DataActCard GetD(int idx)
        {
            if (!isLoaded)
            {
                InitCard();
            }
            var item = cardDatas.Find(x => x.index == idx);
            return item;
        }

        public static DataActCard GetData(int id)
        {
            return I.GetD(id);
        }

    }

}

