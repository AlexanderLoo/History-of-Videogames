using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private Demo demo;
	private SpawnsController spawnsController;
	public GameObject lives, waitingText, player, gameOver;
	private bool waitingState = true;
	private Life playerLife;

	void Start(){

		demo = GetComponent<Demo> ();
		spawnsController = GetComponent<SpawnsController> ();
		playerLife = player.GetComponent<Life> ();
	} 

	void Update(){
		/*Si estamos en el estado de espera y presionamos "Space", iniciamos el juego desactivando el demo, habilitamos el script que spawnea los asteroides,
		 habilitamos las vidas del jugador, el jugador mismo y desactivamos el texto "1 coin 1 play"*/
		if (waitingState) {
			if (Input.GetKeyDown (KeyCode.Space)) {

				demo.enabled = false;
				spawnsController.enabled = true;
				lives.SetActive (true);
				player.SetActive (true);
				waitingText.SetActive (false);

				/*Creamos una lista con todos los asteroides que existen en la escena en ese momento, y por cada una de ellas los destruimos.
				Esto sirve para limpiar los asteroides previamente creados por la demo y así comenzar el juego con nuevos asteroides*/
				GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
				foreach (GameObject enemy in enemies) {
					Destroy (enemy);
				}
				waitingState = false;
			}
		}
		//Si al player no le queda mas vidas, terminamos el juego
		if (playerLife.life == 0) {
			GameOverState ();
		}
	}

	void GameOverState(){
		//Activamos el texto de "Game Over", desactivamos al player y sus vidas, reiniciamos el juego en un breve periodo de tiempo
		gameOver.SetActive (true);
		player.SetActive (false);
		lives.SetActive (false);
		Invoke ("RestartGame", 3);
	}

	void RestartGame(){
		
		SceneManager.LoadScene ("Main");
	}

}
