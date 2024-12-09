using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStart : MonoBehaviour
{
   public GameObject CardSelected;
   public Vector3 Positionslot;
   public Vector3 Positionselected;
   public Vector3 CameraPosition;
   public GameObject StartReady;
   public Sprite OK;
   public Sprite Ready;
   public Sprite GO;

   public void StartInvoked()
   {
      UIManager.Instance.StartMoveHeadler(Positionslot, Positionselected, CameraPosition, gameObject, CardSelected);
      StartCoroutine("PlayReady");
   }

   private IEnumerator PlayReady()
   {
      Image sr = StartReady.GetComponent<Image>();
      yield return new WaitForSeconds(1f);
      sr.color = new Color(1f, 1f, 1f, 255f);
      sr.sprite = OK;
      yield return new WaitForSeconds(1f);
      sr.sprite = Ready;
      yield return new WaitForSeconds(1f);
      sr.sprite = GO;
      yield return new WaitForSeconds(1f);
      sr.sprite = null;
      sr.color = new Color(1f, 1f, 1f, 0f);
      UIManager.Instance.isReady = true;
      UIManager.Instance.LineParent.SetActive(true);
   }
}
