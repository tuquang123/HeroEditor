using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public void Shooter()
    {
       var bul =  Instantiate(bullet, transform.position, Quaternion.identity);
        bul.transform.parent = gameObject.transform;
    }
}
