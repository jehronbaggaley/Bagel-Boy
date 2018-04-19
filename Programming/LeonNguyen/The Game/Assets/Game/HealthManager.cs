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

	private bool isRespawning;
	private Vector3 respawnPoint;
	public float respawnLength;

	// Use this for initialization
	void Start () {
		currHealth = maxHealth;

		//thePlayer = FindObjectOfType<PlayerController>();

		respawnPoint = thePlayer.transform.position;

		playerHealth.text = "Health: " + currHealth + "/" +maxHealth;
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
		playerHealth.text = "Health: " + currHealth + "/" +maxHealth;
	}

	public void HurtPlayer(int damage, Vector3 direction) {
		if (InvincibilityCounter <= 0) {
			currHealth -= damage;

			if (currHealth <= 0) {
				Respawn ();
			} else {
				thePlayer.Knockback (direction);

				InvincibilityCounter = InvincibilityLength;

				playerRenderer.enabled = false;

				flashCounter = flashLength;

				FindObjectOfType<AudioPlayer>().Hurt();
			}
		}
	}
	public void HealPlayer(int healing) {
		currHealth += healing;
		if (currHealth > maxHealth) {
			currHealth = maxHealth;
		}
	}
	public void Respawn(){
		if (!isRespawning) {
			StartCoroutine ("RespawnCo");
		}
	}
	public IEnumerator RespawnCo(){
		isRespawning = true;
		thePlayer.gameObject.SetActive(false);
		FindObjectOfType<AudioPlayer>().Death();
		
		yield return new WaitForSeconds(respawnLength);

		thePlayer.gameObject.SetActive(true);
		isRespawning = false;
		thePlayer.transform.position = respawnPoint;
		currHealth = maxHealth;

		InvincibilityCounter = InvincibilityLength;
		playerRenderer.enabled = false;
		flashCounter = flashLength;
	}

	public void SetSpawnPoint(Vector3 newPosition){
		respawnPoint = newPosition;
	}
}
