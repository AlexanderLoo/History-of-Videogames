using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public GameController gameController;
	public int score = 0;
	public bool scoreCount;

	void Update(){

		//Establecemos el puntaje máximo para terminar el juego
		if (score == 11) {
			gameController.GameEnd ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		//Destruimos la bola y aumentamos el puntaje a 1
			Destroy (other.gameObject);
			score++;
		//scoreCount sirve para saber que se anotó puntaje, esto nos ayuda con la función "SpawnsManager" en GameController
			scoreCount = true;
	}
}
