using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

	public AudioClip hurtSound;
	public AudioClip deathSound;

	public AudioSource soundSource;

	public void Hurt() {
		soundSource.clip = hurtSound;
		soundSource.Play();
	}
	public void Death() {
		soundSource.clip = deathSound;
		soundSource.Play();
	}
}