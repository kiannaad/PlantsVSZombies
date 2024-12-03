using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchwoodControl : MonoBehaviour
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
}
