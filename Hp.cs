using Assets.FantasyMonsters.Scripts.Tweens;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
	public static Hp hp;
    private void Awake()
    {
		hp = this;
    }

	public GameObject FloatTextPrefab;

	public HPBar hPBar;
	public int health = 0;
	public int maxHealth = 10;


	public ManaBar manaBar;
	public float mana = 0;
	public float maxMana = 10;

	void ShowFloatingText(string text)
	{
		var go = Instantiate(FloatTextPrefab, transform.position, Quaternion.identity,transform);
		go.GetComponent<TextMesh>().text = "-"+ text;
	}
	private void Update()
    {
		mana += 0.2f * Time.deltaTime;
		mana = Mathf.Clamp(mana, 0f, maxMana);
		manaBar.SetMana(mana);
	}
    private void Start()
    {
		health = Manager.instace.hp;
		hPBar.SetMaxHealth(maxHealth);
		maxHealth = health;

		manaBar.SetMaxMana(maxMana);
	}
	public GameObject deathEffect;
	public virtual void Spring()
	{
		ScaleSpring.Begin(this, 1f, 1.1f, 40, 2);
	}
	public virtual void TakeDamage(int damage)
	{
		if (FloatTextPrefab && health > 0)
		{
			ShowFloatingText(damage.ToString()) ;
		}
		manaBar.SetMaxMana(maxMana);
		hPBar.SetHealth(health);
		Spring();
		health -= damage;
		if (health <= 0)
		{
			mana = 0;
			Die();
			//shield.SetActive(false);
		}
		if(health <= 60)
        {
			mana+=0.5f;
        }
	}
	void Die()
	{
		GameObject fx = PoolFx.ShareInstance.GetPoolObject();
		if (fx != null)
		{
			fx.transform.position = transform.position;
			fx.transform.rotation = Quaternion.identity;
			fx.SetActive(true);
		}
		gameObject.SetActive(false);
		if (!gameObject.activeSelf)
		{
			Destroy(gameObject, 2f);
		}
	}
}
