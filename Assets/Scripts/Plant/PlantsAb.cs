using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class PlantsAb : MonoBehaviour, IPAttacked
{
     public Vector2 Bulletvelocity;
     public Transform bulletLocation;

     public float Health;
     
     public bool CheckForZombie => Physics2D.Raycast(transform.position, transform.right, Mathf.Infinity, LayerMask.GetMask("Zombie"));

     public virtual void Start()
     {
       
     }

    public virtual void ShootBullet()
    {
       
    }

    public virtual void PlaySound()
    {
        
    }

    public virtual void DeletebyShovel()
    {
        
    }


    public void GetDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0f)
        {
            Destroy(gameObject);
        }
    }
    
}
