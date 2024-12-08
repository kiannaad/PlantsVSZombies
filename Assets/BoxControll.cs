using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;

public class BoxControll : MonoBehaviour
{
   public GameObject light;

   private bool isDarking;
   
   public CardSlotsControl control;

   public void OnPointerClick(BaseEventData eventData)
   {
      Debug.Log("OnPointerClick");
      if (isDarking == false)
      {
         light.transform.SetParent(control.transform);
         control.AddCard(light);
         isDarking = true;
      }
   }
   
}
