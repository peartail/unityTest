using DDatas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorInventory : MonoBehaviour {
    private List<DataActCard> Invencards = null;

    public void InitInventory()
    {
        Invencards = new List<DataActCard>();
    }

    public void AddCard(DataActCard cards)
    {
        cards = new DataActCard();
    }

}
