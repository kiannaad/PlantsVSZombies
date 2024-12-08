using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Zombies : MonoBehaviour, IZAttacked
{
   private Rigidbody2D rb;
   private Animator ani;
   private Animator aniHead;
   private SpriteRenderer sr;
   public Animator aniFire;
   public AudioSource audio1;
   public AudioSource audio2;

   public GameObject Head;
   
   [Header("Move")]
   public float MoveSpeed;
   private bool IsMoving;
   public Vector2 MoveDir;
   private bool CanMove;

   private bool IsDead;
   private bool IsEatting;
   private bool IsAttacking;
   private bool IsPlayingFX;

   public float Health;
   public float attack;
   
   
   private void SetZeroVelocity() => rb.velocity = Vector2.zero;

   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();
      ani = GetComponent<Animator>();
      aniHead= Head.GetComponent<Animator>();
      sr = GetComponent<SpriteRenderer>();
      
      CanMove = true;
   }

   private void Update()
   {
      //Debug.Log(rb.velocity);
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

   #region 造成伤害
   private void OnTriggerEnter2D(Collider2D other)
   {
      //Debug.Log(other.gameObject.name);
      if (other.gameObject.CompareTag("Plant"))
      {
         CanMove = false;
         SetZeroVelocity();
         ani.SetBool("CanEat", true);
         IsEatting = true;
         IsMoving = false;
      }
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.gameObject.CompareTag("Plant"))
      {
         //造成伤害
         if (!IsAttacking)
         StartCoroutine(Attack(other));

         if (!IsPlayingFX)
         {
            AudioManager.Instance.PlayFX(FXType.chomp, audio1);
            AudioManager.Instance.PlayFX(FXType.chompsoft, audio2);
            IsPlayingFX = true;
         }
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      audio1.Stop();
      audio2.Stop();
      if (other.gameObject.CompareTag("Plant"))
      {
         CanMove = true;
         ani.SetBool("CanEat", false);
         IsEatting = false;
         IsPlayingFX = false;
      }
      //AudioManager.Instance.StopFX();
   }
   #endregion

   //实现IZAttacked
   public void GetDamage(float damage, bool IsFire)
   {
      Health -= damage;
      if (Health <= 0)
      {
         if (!IsDead)
         {
               StartCoroutine(ToDead());
         }

         IsDead = true;
      }

      if (IsFire)
      {
         aniFire.SetBool("Fire", false);
         aniFire.SetBool("Fire", true);
      }
   }

   private IEnumerator ToDead()
   {
         aniHead.SetTrigger("LostHead");
         ani.SetBool("CanLostHead", true);
         
         if(IsMoving)
         Head.transform.SetParent(null);
         
         yield return new WaitForSeconds(1.5f);
         
         SetZeroVelocity();
         ani.SetBool("CanDie", true);
   }
   
   private IEnumerator Die()
   {
      sr.DOBlendableColor(new Color(1, 1, 1, 0), .5f);
      yield return new WaitForSeconds(0.5f);
      Destroy(gameObject);
   }

   private IEnumerator Attack(Collider2D other)
   {
      IsAttacking = true;
      other.GetComponent<IPAttacked>().GetDamage(attack);
      yield return new WaitForSeconds(1f);
      IsAttacking = false;
   }

   public void DieTrigger() => StartCoroutine(Die());
}
