using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchwoodControl : PlantsAb, IPAttacked
{
    private CapsuleCollider2D _capsuleCollider;
    

    private void Start()
    {
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            other.GetComponent<Animator>().SetBool("CanFire", true);
            other.GetComponent<BulletBase>().causeDamage += 5;
        }
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
