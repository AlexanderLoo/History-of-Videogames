using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public BoxCollider2D rightWall, leftWall;
	public ScoreManager rightCount, leftCount;
	public GameObject rightRacket, leftRacket;
	public Transform[] spawn;
	public GameObject ball;
	public GameObject ballDemo;
	public BackgroundFlash backgroundFlash;

	public int i;
	private int[] _randomY = { -1, 1 };
	private bool changeSpawn;
	private bool inGame;

	void Start(){
		ball.GetComponent<AudioSource> ().enabled = true;
		ballDemo.GetComponent<BallMovement> ().speed = 5;
		inGame = false;
	}

	void Update(){

		i = Random.Range (0, 2);
		if (Input.GetKeyDown (KeyCode.Space) && !inGame) {
			GameStart ();
		}
		if (backgroundFlash.gameStart) {
			Flash ();
		}
		if (inGame) {
			SpawnsManager ();
		}
	}

	void GameStart(){

		Destroy (ballDemo);
		rightWall.isTrigger = true;
		leftWall.isTrigger = true;
		rightRacket.SetActive (true);
		leftRacket.SetActive (true);
		ball.GetComponent<BallMovement> ().speed = 5;
		Invoke ("RandomSpawn", 1.5f);
		backgroundFlash.gameStart = true;
		inGame = true;
	}

	void SpawnsManager(){

		if (changeSpawn) {
			if (rightCount.scoreCount) {
				ball.GetComponent<BallMovement> ().dir = new Vector2 (1, _randomY[i]);
				Invoke ("BottomSpawn", 2);
				rightCount.scoreCount = false;
				changeSpawn = false;
			}
			if (leftCount.scoreCount) {
				ball.GetComponent<BallMovement> ().dir = new Vector2 (-1, _randomY[i]);
				Invoke ("BottomSpawn", 2);
				leftCount.scoreCount = false;
				changeSpawn = false;
			}
		} else {
			if (rightCount.scoreCount) {
				ball.GetComponent<BallMovement> ().dir = new Vector2 (1, _randomY[i]);
				Invoke ("TopSpawn", 2);
				rightCount.scoreCount = false;
				changeSpawn = true;
			}
			if (leftCount.scoreCount) {
				ball.GetComponent<BallMovement> ().dir = new Vector2 (-1, _randomY[i]);
				Invoke ("TopSpawn", 2);
				leftCount.scoreCount = false;
				changeSpawn = true;
			}
		}
	}

	void TopSpawn(){
		Instantiate (ball, spawn[0]);
	}

	void BottomSpawn(){
		Instantiate (ball, spawn[1]);
	}

	void RandomSpawn(){
		Instantiate (ball, spawn[i]);
	}

	public void GameEnd(){

		ball.GetComponent<AudioSource> ().enabled = false;
		rightWall.isTrigger = false;
		leftWall.isTrigger = false;
		rightRacket.SetActive (false);
		leftRacket.SetActive (false);
		Invoke ("RestartScene", 5);
	}

	void RestartScene(){

		SceneManager.LoadScene("Main");
	}

	void Flash(){
		backgroundFlash.Flash ();
	}
}
