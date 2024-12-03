
using System.Collections;
using UnityEngine;

public class PeaBulletComtrol : BulletBase
{
    private Animator animator;

    private bool isFire;
    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine("Disappearing");
    }

    private void Update()
    {
      
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
            if (animator.GetBool("CanFire"))
                isFire = true;
            other.gameObject.GetComponent<IZAttacked>().GetDamage(causeDamage, isFire);
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
