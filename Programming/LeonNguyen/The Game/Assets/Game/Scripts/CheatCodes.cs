using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodes : MonoBehaviour {

	public GameObject bagelBoy;
	public GameObject lambo;
	public GameObject goku;
	public GameObject spider;
	public GameObject active;

	public PlayerController player;

	// Use this for initialization
	void Start () {
		active = bagelBoy;

		player = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			if (active != bagelBoy) {
				active.SetActive (false);
				bagelBoy.SetActive (true);
				active = bagelBoy;
			}
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			if (active != lambo) {
				active.SetActive (false);
				lambo.SetActive (true);
				active = lambo;
				player.moveSpeed = 100;
				player.jumpForce = 5;
			}
		}
		if (Input.GetKeyDown (KeyCode.G)) {
			if (active != goku) {
				active.SetActive (false);
				goku.SetActive (true);
				active = goku;
			}
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			if (active != spider) {
				active.SetActive (false);
				spider.SetActive (true);
				active = spider;
			}
		}
	}
}
