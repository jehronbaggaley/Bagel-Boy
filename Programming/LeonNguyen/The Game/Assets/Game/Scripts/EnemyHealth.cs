using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth;
	public int currHealth;

	//SCRIPT STUFF NEEDED

	public float InvincibilityLength;
	private float InvincibilityCounter;

	public Renderer enemyRenderer;
	private float flashCounter;
	public float flashLength = 0.1f;

	// Use this for initialization
	void Start () {
		currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (InvincibilityCounter > 0) {
			InvincibilityCounter -= Time.deltaTime;

			flashCounter -= Time.deltaTime;
			if (flashCounter <= 0) {
				enemyRenderer.enabled = !enemyRenderer.enabled;
			}

			if (InvincibilityCounter <= 0) {
				enemyRenderer.enabled = true;
			}
		}
	}

	public void HurtPlayer(int damage, Vector3 direction) {
		if (InvincibilityCounter <= 0) {
			currHealth -= damage;

			if (currHealth <= 0) {
				Destroy (this.gameObject);
			} else {
				//SOMETHING.Knockback (direction);

				InvincibilityCounter = InvincibilityLength;

				enemyRenderer.enabled = false;

				flashCounter = flashLength;

				//FindObjectOfType<AudioPlayer>().Hurt();
			}
		}
	}
}
