using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFire : MonoBehaviour
{
    public void Back() => GetComponent<Animator>().SetBool("Fire", false);
}
