using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HeadDestroy : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    public IEnumerator Die()
    {
        sr.DOBlendableColor(new Color(1, 1, 1, 0), .5f);
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
    
}
