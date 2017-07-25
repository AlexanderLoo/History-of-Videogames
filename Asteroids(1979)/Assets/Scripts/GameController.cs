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

		if (waitingState) {
			if (Input.GetKeyDown (KeyCode.Space)) {

				demo.enabled = false;
				spawnsController.enabled = true;
				lives.SetActive (true);
				player.SetActive (true);
				waitingText.SetActive (false);

				GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
				foreach (GameObject enemy in enemies) {
					Destroy (enemy);
				}
				waitingState = false;
			}
		}
		if (playerLife.life == 0) {
			GameOverState ();
		}
	}

	void GameOverState(){

		gameOver.SetActive (true);
		player.SetActive (false);
		lives.SetActive (false);
		Invoke ("RestartGame", 3);
	}

	void RestartGame(){
		
		SceneManager.LoadScene ("Main");
	}

}
