using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
   public bool IsGlobal = true;
   private static T _instance;
   private readonly static object _lock = new object();

   public static T Instance
   {
      get
      {
         if (_instance == null)
         {
            lock (_lock)
            {
               if (_instance == null)
               {
                  _instance = FindObjectOfType(typeof(T)) as T;
                  if (_instance == null)
                  {
                     GameObject obj = new GameObject();
                     _instance = obj.AddComponent<T>();
                  }
               }
            }
         }

         return _instance;
      }
   }

   public virtual void Awake()
   {
      if (_instance != null && _instance != this)
      {
         Destroy(this.gameObject);
         return;
      }
      
      _instance = this as T;
      if (IsGlobal)
      DontDestroyOnLoad(this.gameObject);
   }
}
