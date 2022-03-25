using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoss : MonoBehaviour
{
    public float time;
    public GameObject Boss;
    private void Start()
    {
        StartCoroutine(Boss1());
    }
    IEnumerator Boss1()
    {
        yield return new WaitForSeconds(time);
        Boss.SetActive(true);
    }
}
