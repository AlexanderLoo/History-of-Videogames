using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Rigidbody2D _rigidbody;
	private GameObject player;
	private ScoreManager scoreDisplay;
	public GameObject[] smallEnemy, midEnemy;
	public float speed;
	public int score;
	public bool big,mid;

	void Start(){

		_rigidbody = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		scoreDisplay = GameObject.Find ("Score").GetComponent<ScoreManager> ();
		_rigidbody.velocity = transform.up * speed;
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag ("Player")) {

			player.GetComponent<Life> ().life -= 1;
		}

		if (other.CompareTag ("Bullet")) {

			if (big) {
				for (int i = 0; i < 2; i++) {
					Quaternion newQuaternion = Quaternion.Euler (0, 0, Random.Range (0, 360));
					Instantiate (midEnemy[Random.Range(0,midEnemy.Length)], transform.position, newQuaternion);
				}
			}
			if (mid) {
				for (int i = 0; i < 2; i++) {
					Quaternion newQuaternion = Quaternion.Euler (0, 0, Random.Range (0, 360));
					Instantiate (smallEnemy[Random.Range(0,smallEnemy.Length)], transform.position, newQuaternion);
				}
			}
			scoreDisplay.AddScore (score);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
