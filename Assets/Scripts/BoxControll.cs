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
   public GameObject Prefab;

   private void Awake()
   {
      returnPositon = transform.position;
   }

   private void Update()
   {
      if (isDarking && UIStartGame.Instance.isReady)
      {
         Instantiate(Prefab, transform.position, Quaternion.identity, CardSlots.transform);
         Destroy(gameObject);
      }
   }
   
   public void OnMouseDown()
   {
      Debug.Log("OnPointerClick");
      if (!isMoving)
      {
         if (isDarking == false && CardSlots.currentPoint < 8)
         {
            transform.SetParent(CardSlots.transform);
            CardSlots.AddCard(this.gameObject);
            isDarking = true;
         }
         else if (isDarking == true)
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
