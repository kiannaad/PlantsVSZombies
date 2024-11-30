using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : NewSingleton<Test>
{
    public void test()
    {
        Debug.Log("test");
    }
}
