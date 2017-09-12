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

		//Al chocar con el player le reducimos la vida en 1
		if (other.CompareTag ("Player")) {

			player.GetComponent<Life> ().life -= 1;
		}
		//Al ser impactado por una bala, dependiendo del tamaño del asteroide hacemos lo siguiente:
		if (other.CompareTag ("Bullet")) {
			//Si el asteroide es grande, creamos 2 asteroides medianos(de cualquiera de los 3 tipos) con rotación aleatoria(para que se vayan en direcciones aleatorias)
			if (big) {
				for (int i = 0; i < 2; i++) {
					Quaternion newQuaternion = Quaternion.Euler (0, 0, Random.Range (0, 360));
					Instantiate (midEnemy[Random.Range(0,midEnemy.Length)], transform.position, newQuaternion);
				}
			}
			//Lo mismo si el asteoride impactado es de tamaño mediano, instanciamos asteroides pequeños
			if (mid) {
				for (int i = 0; i < 2; i++) {
					Quaternion newQuaternion = Quaternion.Euler (0, 0, Random.Range (0, 360));
					Instantiate (smallEnemy[Random.Range(0,smallEnemy.Length)], transform.position, newQuaternion);
				}
			}
			//Llamamos la función que agrega score y destruimos la bala y el asteroide impactado
			scoreDisplay.AddScore (score);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
