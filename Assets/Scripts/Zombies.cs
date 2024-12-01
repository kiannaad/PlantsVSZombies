using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour, IZAttacked
{
   private Rigidbody2D rb;
   private Animator ani;
   
   [Header("Move")]
   public float MoveSpeed;
   private bool IsMoving;
   public Vector2 MoveDir;
   private bool CanMove;

   public float Health;
   
   private void SetZeroVelocity() => rb.velocity = Vector2.zero;

   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();
      ani = GetComponent<Animator>();
      
      CanMove = true;
   }

   private void Update()
   {
      
   }

   private void FixedUpdate()
   {
      if (CanMove)
      Move();
   }

   private void Move()
   {
      rb.velocity = new Vector2(Time.deltaTime, 0) * MoveSpeed * MoveDir;
      IsMoving = true;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      Debug.Log(other.gameObject.name);
      if (other.gameObject.CompareTag("Plant"))
      {
         CanMove = false;
         SetZeroVelocity();
         ani.SetBool("CanEat", true);
      }
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Plant"))
      {
         //造成伤害
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.CompareTag("Plant"))
      {
         CanMove = true;
         ani.SetBool("CanEat", false);
      }
   }

   public void GetDamage(float damage)
   {
      Health -= damage;
      if (Health <= 0)
      {
         ani.SetBool("CanDie", true);
      }
   }
}
