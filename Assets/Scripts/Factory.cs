using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.PlayerLoop;
using UnityEngine.ResourceManagement.AsyncOperations;

public enum BulletType
{
   PeaBullet
}

public enum DropType
{
    Sum
}

public class Factory : MonoSingleton<Factory>
{
      [SerializeField] private Dictionary<string, GameObject> BulletPrefabs = new Dictionary<string, GameObject>();
      [SerializeField] private Dictionary<string, GameObject> DropPrefabs = new Dictionary<string, GameObject>();

      private void Awake()
      {
          StartCoroutine(InitDictionary("bullet", BulletPrefabs));
          StartCoroutine(InitDictionary("drop", DropPrefabs));
      }

      public void CreateBUllet(BulletType type, Vector2 ShootVelocity, Vector2 BullletPosition)
      {
          if (BulletPrefabs.ContainsKey(type.ToString()))
          {
              GameObject bullet = Instantiate(BulletPrefabs[type.ToString()], BullletPosition, Quaternion.identity);

              Rigidbody2D bulletR = bullet.GetComponent<Rigidbody2D>();
              bulletR.velocity = ShootVelocity * new Vector2(Time.deltaTime, Time.deltaTime);
          }
      }

      public void CreateSum(DropType type, Vector2 Position, int count)
      {
          if (DropPrefabs.ContainsKey(type.ToString()))
          {
              GameObject drop = Instantiate(DropPrefabs[type.ToString()], Position, Quaternion.identity);
          }
      }

      private IEnumerator InitDictionary(string Label, Dictionary<string, GameObject> Prefabs)
      {
          var locationsAsync = Addressables.LoadResourceLocationsAsync(Label, typeof(GameObject));

          if (!locationsAsync.IsDone)
              yield return locationsAsync;
          
          List<AsyncOperationHandle> _handles = new List<AsyncOperationHandle>();

          foreach (var resourceLocation in locationsAsync.Result)
          {
              var asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(resourceLocation);
              
              asyncOperationHandle.Completed += init =>
              {
                  Prefabs.Add(resourceLocation.PrimaryKey, asyncOperationHandle.Result);
              };
              
                  _handles.Add(asyncOperationHandle);
          }
          
          var Group = Addressables.ResourceManager.CreateGenericGroupOperation(_handles);
          
          if (!Group.IsDone)
              yield return Group;
          
          Addressables.Release(Group);

          foreach (var item in Prefabs)
          {
              Debug.Log(item.Key + " : " + item.Value.name);
          }
      }
}
