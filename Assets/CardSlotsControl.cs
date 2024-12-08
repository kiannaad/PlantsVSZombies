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

    private int currentPoint = 0;
    private void Start()
    {
        positions = new Vector2[8];
        for (int i = 0; i < 8; i++)
        {
            positions[i] = location[i].transform.position;
        }
    }

    public void AddCard(GameObject card)
    {
        Cards.Add(card);
        Move(card);
    }

    public void RemoveCard(GameObject card)
    {
        Cards.Remove(card);
        CheckForfill();
    }


    public void CheckForfill()
    {
        for (int i = Cards.Count - 1; i >= 0; i--)
        {
            if (Cards[i - 1] == null)
            {
                //����˿�����Ƶ�ǰһ��λ��
                MoveToNext(i);
                currentPoint--;
            }
        }
    }

    private void MoveToNext(int chos)
    {
        for (int i = chos; i < Cards.Count; i++)
        {
            Cards[i].transform.DOMove(positions[i - 1], .2f);
        }
    }

    private void Move(GameObject card)
    {
        if (currentPoint < 8)
        card.transform.DOMove(positions[currentPoint ++], .2f);
        else
        {
            Debug.Log("������Χ��");
        }
    }
}
