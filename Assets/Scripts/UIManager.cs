using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    private Action<Vector3, Vector3, Vector3, GameObject, GameObject> startUi;
    public bool isReady =  false;
    public GameObject LineParent;

    private void Awake()
    {
        IsGlobal = false;
        LineParent.SetActive(false);
        isReady = false;
        startUi += MoveStart;
    }
    
    #region 开始摇滚吧
    //开始摇滚
    public void StartMoveHeadler(Vector3 position1, Vector3 position2, Vector3 CameraPosition, GameObject CardSlots, GameObject CardSelected) => startUi?.Invoke(position1, position2, CameraPosition, CardSlots, CardSelected);
    
    private void MoveStart(Vector3 position1, Vector3 position2, Vector3 CameraPosition, GameObject CardSlots, GameObject CardSelected) 
        => StartCoroutine(MoveToStartPosition(position1, position2, CameraPosition, CardSlots, CardSelected));
    
   
    private IEnumerator MoveToStartPosition(Vector3 position1, Vector3 position2, Vector3 CameraPosition, GameObject CardSlots, GameObject CardSelected)
    {
        RectTransform rectTransformSelected = CardSelected.GetComponent<RectTransform>();
        RectTransform rectTransformSlots = CardSlots.GetComponent<RectTransform>();
        
        while (rectTransformSelected.anchoredPosition.y > position2.y + 5f)
            rectTransformSelected.anchoredPosition = Vector3.MoveTowards(rectTransformSelected.anchoredPosition, position2, Time.deltaTime * 10f);
        
        yield return new WaitForSeconds(.1f);
        Destroy(CardSelected);
        
        while (rectTransformSlots.anchoredPosition.x > position1.x + 5f)
            rectTransformSlots.anchoredPosition = Vector3.MoveTowards(rectTransformSlots.anchoredPosition, position1, Time.deltaTime * 10f);
        
        Camera.main.transform.DOMove(CameraPosition, 0.1f);
        
        yield return new WaitForSeconds(1f);
         
    }
    #endregion 
}
