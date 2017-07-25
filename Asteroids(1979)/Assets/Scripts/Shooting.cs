using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject bullet;
	public Transform shotSpawn;

	void Update(){

		bool shot = Input.GetButtonDown ("Fire1");
		if (shot) {
			Instantiate (bullet, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
