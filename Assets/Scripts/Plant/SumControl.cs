using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class SumControl : MonoBehaviour
{
    /*[SerializeField] private float SumHight;
    [SerializeField] private float currentHight;
    [SerializeField] private float a;
    [SerializeField] private float t;
    [SerializeField] private float Gap;

    private bool DontMove;*/

    private Transform sum;
    public Vector2 MoveTo;
    private bool IsMoving;

    private void Awake()
    {
        /*currentHight = transform.position.y;
        SumHight += currentHight;
        a = Physics.gravity.y;
        t = 0;
        DontMove = false;*/

        sum = GetComponent<Transform>();
        sum.localScale = new Vector3(0, 0, 0);
    }

    void Start()
    {
       sum.DOScale(new Vector3(1, 1, 1), 1f);
       StartCoroutine("CountDown");
    }
    
    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine("Delete");
    }
    
    private IEnumerator Delete()
    {
        if (!IsMoving)
        {
            gameObject.GetComponent<SpriteRenderer>().DOBlendableColor(new Color(0, 0, 0, 0), 1f);
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        StartCoroutine("MouseDown");
    }

    private IEnumerator MouseDown()
    {
        IsMoving = true;
        transform.DOMove(MoveTo, 2f);
        yield return new WaitForSeconds(2f);
        GetSunNum.Instance.ModifySunUp(50);
        Destroy(gameObject);
    }
    /*private void Push()
    {
        if (!DontMove)
        {
            if (transform.position.y < SumHight)
            {
                transform.position = new Vector2(transform.position.x, currentHight + 0.5f * -a * t * t);
                t += Time.deltaTime * Gap;
            }
        }

        if (transform.position.y >= SumHight)
            DontMove = true;
        
        if (DontMove)
            Back();
    }

    private void Back()
    {
        if (transform.position.y > currentHight)
        {
            transform.position = new Vector2(transform.position.x, currentHight + 0.5f * -a * t * t);
            t -= Time.deltaTime * Gap;
        }
    }*/
    
}
