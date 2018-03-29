using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

	public int maxHealth;
	public int currHealth;

	// Use this for initialization
	void Start () {
		currHealth = maxHealth;
	}

	public void HurtPlayer(int damage) {
		currHealth -= damage;
	}
	public void HealPlayer(int healing) {
		currHealth += healing;
		if (currHealth > maxHealth) {
			currHealth = maxHealth;
		}
	}
}
