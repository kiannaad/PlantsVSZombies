using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class BoxControll : MonoBehaviour
{
   private Vector3 returnPositon;

   private bool isDarking;
   public bool isMoving;
   
   public CardSlotsControl CardSlots;
   public GameObject Dark;

   private void Awake()
   {
      returnPositon = transform.position;
   }
   
   public void OnMouseDown()
   {
      Debug.Log("OnPointerClick");
      if (!isMoving)
      {
         if (isDarking == false)
         {
            transform.SetParent(CardSlots.transform);
            CardSlots.AddCard(this.gameObject);
            isDarking = true;
         }
         else
         {
            transform.SetParent(Dark.transform);
            StartCoroutine(Returnmove());
            CardSlots.RemoveCard(this.gameObject);
            isDarking = false;
            
         }
      }
   }

   private IEnumerator Returnmove()
   {
      isMoving = true;
      transform.DOMove(returnPositon, 0.5f);
      yield return new WaitForSeconds(0.5f);
      isMoving = false;
   }
   
}
