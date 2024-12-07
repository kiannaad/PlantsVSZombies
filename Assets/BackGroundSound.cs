using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSound : MonoBehaviour
{

    private void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
           AudioManager.Instance.PlayBGM(BGMType.Progress,this.gameObject.GetComponent<AudioSource>());
    }
}
