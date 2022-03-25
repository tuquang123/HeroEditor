using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    [Header("Object Destroy")]
    public GameObject playerManager;
    public GameObject hero;

    public static PlayerSpawn instance;
    public List<Transform> objects = new List<Transform>();
    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void RemoveList()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            Transform obj = this.objects[i];
            if (obj.gameObject.activeSelf) continue;
            objects.Remove(obj);
            if (objects.Count == 0)
            {
                Debug.Log("EnemyWin");
            }
        }
    }
    private void LateUpdate()
    {
        RemoveList();
        if (Input.GetKeyDown(KeyCode.S))
        {
            Next();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Home();
        }

    }
    public void OnPlayer()
    {
        hero.SetActive(gameObject);
        GameObject fx = PoolFx.ShareInstance.GetPoolObject();
        if (fx != null)
        {
            fx.transform.position = transform.position;
            fx.transform.rotation = Quaternion.identity;
            fx.SetActive(true);
        }
    }
    public void Next()
    {
        Manager.instace.Save();
        SceneManager.LoadScene(1);
        Invoke("OnPlayer", 1f);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
        Destroy(playerManager);
        Manager.instace.Load();
    }
    public void Skill1()
    {
        Hp.hp.mana = 0;
    }
}
