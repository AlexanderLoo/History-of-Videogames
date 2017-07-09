using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	public float speed = 5;
	public Vector2 dir = new Vector2 (1, -1);
	private int[] _random = {-1,1};
	public bool demo;

	private AudioSource _audio;

	void Start(){

		_audio = GetComponent<AudioSource> ();
		if (demo) {
			int x = Random.Range (0, 2);
			int y = Random.Range (0, 2);
			dir = new Vector2 (_random [x], _random [y]);
		}
		GetComponent<Rigidbody2D> ().velocity = dir * speed;
		Debug.Log (dir);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (!demo) {
			_audio.Play ();
		}
	}
}
