using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	public float minLimit, maxLimit;
	public GameObject bullet, shotSpawn;

	void Update(){

		float h = Input.GetAxis ("Horizontal");
		bool shot = Input.GetButtonDown ("Fire1");
		PlayerMovement (h);
		Shooting (shot);
	}

	void PlayerMovement(float h){

		Vector3 movement = Vector3.zero;
		movement.x = h * speed * Time.deltaTime;
		transform.Translate (movement);

		Vector3 clampedPosition = transform.position;
		clampedPosition.x = Mathf.Clamp (transform.position.x, minLimit, maxLimit);
		transform.position = clampedPosition;
	}

	void Shooting(bool shot){

		if (shot) {
			Instantiate (bullet, shotSpawn.transform.position, shotSpawn.transform.rotation);
		}
	}
}
