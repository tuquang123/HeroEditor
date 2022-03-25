using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public int collisionCount = 0;
    public bool gg = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            collisionCount = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            collisionCount = 1;
        }
    }
    private void Update()
    {
        if(collisionCount == 1)
        {
            gg = false;
        }
        if(collisionCount == 0)
        {
            gg = true;
        }
    }

}
