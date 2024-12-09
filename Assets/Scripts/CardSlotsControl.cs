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

    public int currentPoint = 0;
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
        StartCoroutine(FillMove(card));
    }

    public void RemoveCard(GameObject card)
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            if (Cards[i] == card)
            {
                StartCoroutine(FillOutMove(i));
                
            }
        }
    }


    public IEnumerator FillOutMove(int j)
    {
        currentPoint--;
        for (int i = j + 1; i < Cards.Count; i++)
        {
            Cards[i].GetComponent<BoxControll>().isMoving = true;
            Cards[i].transform.DOMove(positions[i - 1], .1f);
            yield return new WaitForSeconds(.1f);
        }
        for (int i = j + 1; i < Cards.Count; i++)
        Cards[i].GetComponent<BoxControll>().isMoving = false;
        Cards.RemoveAt(j);
    }

    private IEnumerator FillMove(GameObject card)
    {
        if (currentPoint < 8)
        {
            card.GetComponent<BoxControll>().isMoving = true;
            card.transform.DOMove(positions[currentPoint++], .2f);
            yield return new WaitForSeconds(.2f);
            card.GetComponent<BoxControll>().isMoving = false;
        }
        else
        {
            Debug.Log("³¬³ö·¶Î§ÁË");
        }
    }
}
