using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerInPoint : MonoBehaviour
{
    #region Singelton
    public static SpawnPlayerInPoint instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public Manager manager;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public Transform player1Point;
    public Transform player2Point;
    public Transform player3Point;
    public Transform player4Point;

    public List<Transform> objects = new List<Transform>();

    void RemoveList()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            Transform obj = this.objects[i];
            if (obj.gameObject.activeSelf) continue;
            objects.Remove(obj);
        }
    }
    private void LateUpdate()
    {
        RemoveList();
    }
    private void Start()
    {
        Invoke("Summon", 2f);
    }
    public void Summon()
    {
        GameObject fx = PoolFx.ShareInstance.GetPoolObject();
        if (fx != null)
        {
            fx.transform.position = player1Point.position;
            fx.transform.rotation = Quaternion.identity;
            fx.SetActive(true);
        }
        var p1 = Instantiate(player1, player1Point.position, Quaternion.identity);
        p1.transform.parent = gameObject.transform;
        objects.Add(p1.gameObject.transform);
        p1.GetComponent<Hp>().health = manager.hp;
        //p1.GetComponent<Fl>().dame = manager.dame;
        p1.GetComponent<Fl>().speed = manager.speed;
        p1.GetComponentInChildren<ATT>().attackSpeed = manager.attackSpeed;

        var p2 = Instantiate(player2, player2Point.position, Quaternion.identity);
        p2.transform.parent = gameObject.transform;
        objects.Add(p2.gameObject.transform);

        var p3 = Instantiate(player3, player3Point.position, Quaternion.identity);
        p3.transform.parent = gameObject.transform;
        objects.Add(p3.gameObject.transform);

        var p4 = Instantiate(player4, player4Point.position, Quaternion.identity);
        p4.transform.parent = gameObject.transform;
        objects.Add(p4.gameObject.transform);

    }
}
