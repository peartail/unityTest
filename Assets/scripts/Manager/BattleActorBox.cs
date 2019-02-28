using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DDatas;
public class BattleActorBox  {
    public struct BattleCard
    {
        public long itemIndex;
        public DataActCard card;
    }

    private static long cardIndex = 0;
    private List<BattleCard> battleCardsInfo;
    private DataMyActor ActorInfo;
    private List<BattleCard> BattleCardsInfo { get { return battleCardsInfo; } }

    private static BattleActorBox i = null;
    private static BattleActorBox I
    {
        get
        {
            if(i == null)
            {
                i = new BattleActorBox();
            }
            return i;
        }
    }

    public static List<BattleCard> GetBattleCard()
    {
        return I.BattleCardsInfo;
    }

    public static DataMyActor GetBattleMyActor()
    {
        return I.ActorInfo;
    }

    public static void AddBattleCard(DataActCard c)
    {
        I.battleCardsInfo.Add(new BattleCard() { card = c, itemIndex = cardIndex++ });
    }

    public static void RemoveBattleCard(long index)
    {
        int at = I.battleCardsInfo.FindIndex(x => x.itemIndex == index);
        I.battleCardsInfo.RemoveAt(at);
    }

    public static void AddBattleMyActor(DataMyActor actor)
    {
        I.ActorInfo = actor;
    }

}
