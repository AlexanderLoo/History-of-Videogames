using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;

	void Update(){

		Vector3 movement = Vector3.up;
		transform.Translate (movement * speed * Time.deltaTime);
	}
}
