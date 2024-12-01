using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardControl : MonoBehaviour
{
   public GameObject dark;
   public GameObject progress;

   [SerializeField] private float timer;
   [SerializeField] private float coolTime;

   public void InitCard(CardData cardData)
   {
      gameObject.GetComponent<SpriteRenderer>().sprite = cardData.light;
      dark.GetComponent<SpriteRenderer>().sprite = cardData.dark;
      progress.GetComponent<SpriteRenderer>().sprite = cardData.progress;
      timer = cardData.coolTime;
      coolTime = cardData.coolTime;
   }

   public IEnumerator UpdateCard()
   {   
       dark.SetActive(true);
       progress.GetComponent<Image>().DOFillAmount(0, 2f);
       yield return new WaitForSeconds(2f);
       dark.SetActive(false);
   }
}
