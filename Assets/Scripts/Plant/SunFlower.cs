
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SunFlower : MonoBehaviour,IPAttacked
{
    [Header("Time Count")]
    [SerializeField] private float timer;
    [SerializeField] private float ReadyTimer;
    
    private Animator animator;
    private bool CanCount;
    private int sumNum;
    
    private BoxCollider2D boxCollider;

    public float Health;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        timer = ReadyTimer;
        CanCount = true;
        
    }

    private void Update()
    {
        ProduceSum();
    }

    private void ProduceSum()
    {
        if (CanCount)
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            animator.SetBool("SumLight", true);
            timer = ReadyTimer;
            CanCount = false;
        }
    }

    public void GetSum()
    {
        Factory.Instance.CreateSum(DropType.Sum, GetRandomPoint(), 1);
        animator.SetBool("SumLight", false);
        CanCount = true;
    }

    private Vector2 GetRandomPoint()
    {
        float randomX = 0;
        float randomY = 0;
        sumNum++;
        if (sumNum % 2 == 0)
        {
            randomX = Random.Range(transform.position.x - 30, transform.position.x - 20);
        }
        else
        {
            randomX = Random.Range(transform.position.x + 20, transform.position.x + 30);
        }
        randomY = Random.Range(transform.position.y - 20, transform.position.y + 20);
        return new Vector2(randomX, randomY);
    }

    public void GetDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
