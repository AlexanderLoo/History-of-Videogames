using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Rigidbody2D _rigidbody;
	public float speed;

	void Start(){

		_rigidbody = GetComponent<Rigidbody2D> ();
		_rigidbody.velocity = transform.up * speed;
	}
}
