using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxHealth;
	public int currHealth;

	public PlayerController thePlayer;

	public float InvincibilityLength;
	private float InvincibilityCounter;

	public Renderer playerRenderer;
	private float flashCounter;
	public float flashLength = 0.1f;

	public Text playerHealth;

	// Use this for initialization
	void Start () {
		currHealth = maxHealth;

		thePlayer = FindObjectOfType<PlayerController>();

		playerHealth.text = "" + currHealth + "/" +maxHealth;
	}

	void Update () {
		if (InvincibilityCounter > 0) {
			InvincibilityCounter -= Time.deltaTime;

			flashCounter -= Time.deltaTime;
			if (flashCounter <= 0) {
				playerRenderer.enabled = !playerRenderer.enabled;
			}

			if (InvincibilityCounter <= 0) {
				playerRenderer.enabled = true;
			}
		}
		playerHealth.text = "" + currHealth + "/" +maxHealth;
	}

	public void HurtPlayer(int damage, Vector3 direction) {
		if (InvincibilityCounter <= 0) {
			currHealth -= damage;

			thePlayer.Knockback(direction);

			InvincibilityCounter = InvincibilityLength;

			playerRenderer.enabled = false;
			flashCounter = flashLength;
		}
	}
	public void HealPlayer(int healing) {
		currHealth += healing;
		if (currHealth > maxHealth) {
			currHealth = maxHealth;
		}
	}
}
