
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Pea : PlantsAb
{
    private void Awake()
    {
       
    }

    public override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        //Debug.Log(CheckForZombie);
    }

    public override void ShootBullet()
    {
        base.ShootBullet();
        
        if (CheckForZombie)
        Factory.Instance.CreateBUllet(BulletType.PeaBullet, Bulletvelocity,bulletLocation.position);
    }

    public override void PlaySound()
    {
        base.PlaySound();
    }

    public override void DeletebyShovel()
    {
        base.DeletebyShovel();
    }
}
