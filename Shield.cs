using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : ShieldTower
{
    public override void TakeDamage(int damage)
    {
		health -= damage;
		textHp.text = health.ToString();

		if (health <= 0)
		{
			Instantiate(deathEffect, transform.position, Quaternion.identity);
			//shield.SetActive(false);
		}
	}
}
