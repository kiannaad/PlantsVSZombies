using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PeaBulletComtrol : MonoBehaviour
{
    public AsyncOperationHandle<GameObject> PeaBullet;

    private void OnDestroy()
    {

    }
}