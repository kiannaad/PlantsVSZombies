using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
   public float causeDamage;

   public abstract void OnTriggerEnter2D (Collider2D other);
   public abstract void OnTriggerExit2D (Collider2D other);
   
   public abstract void OnTriggerStay2D (Collider2D other);

}
