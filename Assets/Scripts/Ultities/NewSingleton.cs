using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewSingleton<T> where T : new()
{
   private static readonly Lazy<T> lazyInstance = new Lazy<T>(() => new T());

   public T Instance => lazyInstance.Value;
}
