using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   private Dictionary<string, GameObject> UIPrefabs = new Dictionary<string, GameObject>();
   private Dictionary<string, string> UIpaths = new Dictionary<string, string>();

   public GameObject LoadUIPrefabs(string UIname)
   {
      if (UIPrefabs.ContainsKey(UIname))
      {
         return Instantiate(UIPrefabs[UIname]);
      }
      else
      {
         UIPrefabs.Add(UIname, Resources.Load<GameObject>(UIpaths[UIname]));
         return Instantiate(UIPrefabs[UIname]);
      }
   }
   
   
}

public class UIConst
{
   public const string UserName = "UserName";
}
