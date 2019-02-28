using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using DDatas;


public class MyCardTable : MonoBehaviour {
    //MyHand
    //DropCards
    //DeckCards
    Queue<DataActCard> deckCards;
    private int MaxHand = 0;
    List<DataActCard> myHandCards;
    List<DataActCard> dropCards;

    void SettingCard(DataActCard[] myCards,int maxHand)
    {
        if(deckCards == null)
        {
            deckCards = new Queue<DataActCard>();
        }

        if(myHandCards == null)
        {
            myHandCards = new List<DataActCard>();
        }

        if(dropCards == null)
        {
            dropCards = new List<DataActCard>();
        }

        foreach(var card in myCards)
        {
            deckCards.Enqueue(card);
        }

    }

    void StartCardBattle()
    {
        for(int i =0;i<MaxHand; i++)
        {
            DeckToHand();
        }
    }

    void DeckToHand()
    {
        if(deckCards.Count > 0)
        {
            myHandCards.Add(deckCards.Dequeue());
        }
        else
        {
            DropToDeck();
        }

    }

    //버린다.
    void DropCard(DataActCard card)
    {
        dropCards.Add(card);
        myHandCards.Remove(card);
    }


    //카드를 뽑는다.
    void DrawCard(DataActCard card)
    {
        dropCards.Add(card);
        myHandCards.Remove(card);
    }

    //버린카드를 덱으로 이동
    void DropToDeck()
    {
        var suffleCards = SuffleCard(dropCards);
        foreach(var card in suffleCards)
        {
            deckCards.Enqueue(card);
        }
        dropCards.Clear();
    }

    List<DataActCard> SuffleCard(List<DataActCard> cards)
    {
        List<DataActCard> result = new List<DataActCard>();
        while(cards.Count > 0)
        {
            int randomCount = UnityEngine.Random.Range(0, cards.Count - 1);
            result.Add(cards[randomCount]);
            cards.RemoveAt(randomCount);
        }

        return result;
    }
}


public class MyCardTableSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
    }
}
