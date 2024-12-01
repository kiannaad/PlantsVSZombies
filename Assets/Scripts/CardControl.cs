using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

public class CardControl : MonoBehaviour
{
   public GameObject dark;
   public GameObject progress;

   [SerializeField] private int NeedSun;
   [SerializeField] private float coolTime;
   [SerializeField] private PlantType plantType;
   public float Health;

   private bool IsUpdating;

   private GameObject DragObject;
   
   

   private void Awake()
   {
       StartCoroutine(UpdateCard());
   }

   private void Update()
   {
      
   }

   public IEnumerator UpdateCard()
   {   
       IsUpdating = true;
       dark.SetActive(true);
       progress.SetActive(true);
       progress.GetComponent<Image>().fillAmount = 1f;
       progress.GetComponent<Image>().DOFillAmount(0, coolTime);
       yield return new WaitForSeconds(coolTime - 1f);
       IsUpdating = false;
       progress.SetActive(false);
       CheckUse();
   }

   public void CheckUse()
   {
       if (!IsUpdating)
       {
           Debug.Log("Checking use");
           if (GetSunNum.Instance.GetSunNumValue >= NeedSun)
               dark.SetActive(false);
           else
           {
               dark.SetActive(true);
           }
       }
   }

   private void UseCard()
   {
       GetSunNum.Instance.ModifySunDown(NeedSun);
       StartCoroutine(UpdateCard());
   }

   public void BeginDrag(BaseEventData eventData)
   {
       if (!dark.activeInHierarchy)
       {
           DragObject = Factory.Instance.CreatePlant(plantType, Camera.main.ScreenToWorldPoint(Input.mousePosition));
           DragObject.GetComponent<Animator>().speed = 0f;
       }
   }

   public void Drag(BaseEventData eventData)
   {
       if (!dark.activeInHierarchy && DragObject != null)
       {
           //Debug.Log(eventData.ToString());
           DragObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       }
   }

   public void EndDrag(BaseEventData eventData)
   {
       if (!dark.activeInHierarchy && DragObject != null)
       {
           if (Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) && Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)).CompareTag("Land"))
           {
               Collider2D Collider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
               Collider.gameObject.tag = "Untagged";
               DragObject.transform.position = Collider.transform.position - new Vector3(- 30f, 40f, 0f);
               DragObject.GetComponent<Animator>().speed = 1f;
               UseCard();
           }
           else
           {
               Destroy(DragObject);
           }
       }
       
   }
}
