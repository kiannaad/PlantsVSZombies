using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardSlotsControl : MonoBehaviour
{
    public List<GameObject> Cards = new List<GameObject>();
    public GameObject[] location;
    private Vector2[] positions;

    private void Start()
    {
        positions = new Vector2[8];
        for (int i = 0; i < 8; i++)
        {
            positions[i] = location[i].transform.position;
        }
    }

    public void AddCard(GameObject card) => Cards.Add(card);

    public void RemoveCard(GameObject card)
    {
        Cards.Remove(card);
        CheckForfill();
    }


    public void CheckForfill()
    {
        for (int i = Cards.Count - 1; i > 0; i--)
        {
            if (Cards[i - 1] == null)
            {
                //整体丝滑的移到前一个位置
                MoveToNext(i);
            }
        }
    }

    private void MoveToNext(int chos)
    {
        for (int i = chos; i < Cards.Count; i++)
        {
            Move(i);
        }
    }

    private void Move(int i)
    {
        Cards[i].transform.DOMove(positions[i - 1], .2f);
    }
}
