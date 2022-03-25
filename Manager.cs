using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    #region singleton 
    static public Manager instace;
    private void Awake()
    {
        Load();
        instace = this;
    }
    #endregion
    [Header("Gold & Level")]
    public int gold = 0;
    public Text textGold;

    public Text Textlv;
    public int level = 0;
    public int exp = 0;
    public int expNext = 10;
   
    [Header("Profile")]
    public int hp = 100;
    public float attackSpeed = 3;
    public float speed = 1;

    private void Start()
    {
        Textlv.text = level.ToString();
        textGold.text = gold.ToString();
        //do not destroy
        //DontDestroyOnLoad(gameObject);
    }
    public void Save()
    {
        PlayerPrefs.SetInt("lv", level);
        PlayerPrefs.SetInt("exp", exp);
        PlayerPrefs.SetInt("expnext",expNext);
        PlayerPrefs.SetInt("gold", gold);

        PlayerPrefs.SetInt("hp", hp);
        PlayerPrefs.SetFloat("speed", speed);
        PlayerPrefs.SetFloat("attackspeed", attackSpeed);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        hp = PlayerPrefs.GetInt("hp",100);
        gold = PlayerPrefs.GetInt("gold",0);
        level = PlayerPrefs.GetInt("lv",1);
        exp = PlayerPrefs.GetInt("exp",1);
        expNext = PlayerPrefs.GetInt("nextexp",10);
        attackSpeed = PlayerPrefs.GetFloat("attackspeed",3);
        speed = PlayerPrefs.GetFloat("speed",1);
    }
    void OnApplicationQuit()
    {
        Save();
    }
    void OnGUI()
    {
        //Fetch the PlayerPrefs settings and output them to the screen using Labels
        GUI.Label(new Rect(100, 130, 200, 40), "Hp : " + hp);
        GUI.Label(new Rect(100, 140, 200, 40), "lv : " + level);
        GUI.Label(new Rect(100, 150, 200, 40), "gold : " + gold);
        GUI.Label(new Rect(100, 160, 200, 40), "speed : " + speed);
        GUI.Label(new Rect(100, 170, 200, 40), "attackspeed : " + attackSpeed);
        GUI.Label(new Rect(100, 180, 200, 40), "exp : " + exp);
    }
    private void FixedUpdate()
    {
        textGold.text = gold.ToString();
        if (exp == expNext)
        {
            level++;
            Textlv.text = level.ToString();
            expNext *= 2;
            exp = 0;
        }
    }
    
}
