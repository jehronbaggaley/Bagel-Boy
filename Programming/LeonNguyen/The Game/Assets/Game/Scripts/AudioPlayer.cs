using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

	public AudioClip hurtSound;
	public AudioClip deathSound;
	public AudioClip projectile;
	public AudioClip enemyHurt;
	public AudioClip enemyDeath;

	public AudioSource soundSource;

	public void Hurt() {
		Debug.Log ("hit");
		soundSource.clip = hurtSound;
		soundSource.Play();
	}
	public void Death() {
		soundSource.clip = deathSound;
		soundSource.Play();
	}
	public void Throw() {
		soundSource.clip = projectile;
		soundSource.Play ();
	}
	public void EnemyHurt() {
		soundSource.clip = enemyHurt;
		soundSource.Play ();
	}
	public void EnemyDeath() {
		soundSource.clip = enemyDeath;
		soundSource.Play ();
	}
}