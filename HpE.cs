using Assets.FantasyMonsters.Scripts.Tweens;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpE : MonoBehaviour
{
	
	public int health = 10;
    public virtual void Spring()
	{
		ScaleSpring.Begin(this, 1f, 1.1f, 40, 2);
	}
	public virtual void TakeDamage(int damage)
	{
		Spring();
		health -= damage;
		if (health <= 0)
		{
			Die();
			//shield.SetActive(false);
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
