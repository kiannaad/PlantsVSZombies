using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlotsManager : MonoSingleton<CardSlotsManager>
{
    public GameObject CardSlotsParent;
    public CardControl[] CardSlots;

    public GameObject SunNum;

    private void Awake()
    {
        CardSlots = new CardControl[8];
        CardSlots = CardSlotsParent.GetComponentsInChildren<CardControl>();
    }

    private void Start()
    {
        UpdateCardSlots();
    }


    public void UpdateCardSlots()
    {
        foreach (var cardSlot in CardSlots)
        {
            cardSlot.StartCoroutine("UpdateCard");
        }
    }
}
