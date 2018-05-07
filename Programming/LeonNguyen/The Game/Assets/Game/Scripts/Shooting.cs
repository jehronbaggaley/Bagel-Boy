using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject prefab;

	public Transform camTrans;
	public Transform playerTrans;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject projectile = Instantiate (prefab) as GameObject;
			projectile.transform.rotation = camTrans.rotation;
			projectile.transform.position = playerTrans.position + camTrans.forward * 2;
		}
	}
}
