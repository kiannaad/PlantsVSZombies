using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PeaBulletComtrol : BulletBase
{
    private void Start()
    {
        StartCoroutine("Disappearing");
    }

    private IEnumerator Disappearing()
    {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zomby"))
        {
            other.gameObject.GetComponent<IZAttacked>().GetDamage(causeDamage);
            Destroy(this.gameObject);
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        
    }

    public override void OnTriggerStay2D(Collider2D other)
    {

    }
}
