using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEnemy : MonoBehaviour
{
    public GameObject enemy;
    private void Start()
    {
        Invoke("On", 10f);
    }
    public void On()
    {
        enemy.SetActive(true);
    }
}
