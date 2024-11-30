using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantsAb : MonoBehaviour
{
     public Vector2 Bulletvelocity;
     public Transform bulletLocation;

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
}
