using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePlayer : MonoBehaviour
{
    private Vector3 targetPosition;
    public float speed;
    //public GameObject deathEffect;

    private void Start()
    {
        //Destroy(gameObject, 10f);
        if (targetPosition == null) return;
        targetPosition = FindObjectOfType<HpE>().transform.position;
    }
    private void Update()
    {
            transform.position =
    Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if(targetPosition == transform.position)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GameObject fx = PoolFx.ShareInstance.GetPoolObject();
            if (fx != null)
            {
                fx.transform.position = transform.position;
                fx.transform.rotation = Quaternion.identity;
                fx.SetActive(true);
            }
        }
    }
}
