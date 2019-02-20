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
        public int value;
    }

}

