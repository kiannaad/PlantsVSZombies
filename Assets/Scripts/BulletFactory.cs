using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class BulletFactory : MonoSingleton<BulletFactory>
{
   [SerializeField] private Type bulletType;
   [SerializeField] private Vector3 bulletPosition;
   [SerializeField] private Vector3 bullletVelocity;
   enum BulletType
   {
      PeaBullet
   }

   public void CreateBullet(Type bulletType, Vector3 CreatePosiiton, Vector3 bulletVelocity)
   {
      Init(bulletType, CreatePosiiton, bulletVelocity);
      
      var bullet = Addressables.LoadAssetAsync<GameObject>("Bullets/" + bulletType.Name);
      bullet.Completed += InitBullet;
   }

   private void Init(Type bulletType, Vector3 CreatePosiiton, Vector3 bulletVelocity)
   {
      this.bulletType = bulletType;
      this.bulletPosition = CreatePosiiton;
      this.bullletVelocity = bulletVelocity;
   }
   
   
   private void InitBullet(AsyncOperationHandle<GameObject> obj)
   {
      //初始化速度以及数量
   }
   
   public override void Awake()
   {
      base.Awake();
   }
}
