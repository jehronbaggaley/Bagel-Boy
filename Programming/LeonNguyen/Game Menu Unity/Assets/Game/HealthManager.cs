using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

	public int maxHealth;
	public int currHealth;

	public PlayerController thePlayer;

	public float InvincibilityLength;
	private float InvincibilityCounter;

	// Use this for initialization
	void Start () {
		currHealth = maxHealth;

		thePlayer = FindObjectOfType<PlayerController>();
	}

	void Update () {
		if (InvincibilityCounter > 0) {
			InvincibilityCounter -= Time.deltaTime;
		}
	}

	public void HurtPlayer(int damage, Vector3 direction) {
		if (InvincibilityCounter <= 0) {
			currHealth -= damage;

			thePlayer.Knockback(direction);

			InvincibilityCounter = InvincibilityLength;
		}
	}
	public void HealPlayer(int healing) {
		currHealth += healing;
		if (currHealth > maxHealth) {
			currHealth = maxHealth;
		}
	}
}
