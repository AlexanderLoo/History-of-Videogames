using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public BoxCollider2D rightWall, leftWall;
	//puntajes del jugador de la derecha y de la izquierda
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
		//Al presionar espacio en la pantalla de espera iniciamos el juego
		if (Input.GetKeyDown (KeyCode.Space) && !inGame) {
			GameStart ();
		}
		//Si se inció el juego llamamos una función que se encarga de hacer un efecto de flash(parecido al pong original)
		if (backgroundFlash.gameStart) {
			Flash ();
		}
		//Mientras estamos en el estado "En Juego" llamamos la función SpawnManager que permite spawnear las bolas
		if (inGame) {
			SpawnsManager ();
		}
	}

	void GameStart(){
		/*Esta función se encarga de inciar el juego: destruimos la bola demo, activamos los trigger para el puntaje, activamos las raquetas,
		seteamos la velocidad de la bola por default para corregir la velocidad acumulada por partidas anteriores, activamos 2 booleanos: 
		-para hacer el efecto flash
		-para crear un estado "En Juego"*/
		Destroy (ballDemo);
		rightWall.isTrigger = true;
		leftWall.isTrigger = true;
		rightRacket.SetActive (true);
		leftRacket.SetActive (true);
		ball.GetComponent<BallMovement> ().speed = 5;
		//Invocamos una función que se encarga de spawnear una bola en dirección y spawn aleatorio
		Invoke ("RandomSpawn", 1.5f);
		backgroundFlash.gameStart = true;
		inGame = true;
	}
	/*Quizás este algoritmo sea un poco complicado y redundante ya que esta es mi primera recreación de videojuego y mi experiencia en programación es mínima.
	La idea es que cada vez que un jugador anota, el siguiente saque va ser a la misma dirección pero con la coordena 'Y' aleatoria(-1,1) y alternando los spawns
	de arriba y de abajo*/
	void SpawnsManager(){

		//changeSpawn sirve para alternar el spawn de arriba y el de abajo, cada vez que se anota un punto, se alterna los spawns
		if (changeSpawn) {
			//Si se anotó puntaje en la derecha, la dirección de la bola siempre va ser a la derecha pero con la coordenada de 'Y' aleatoria
			if (rightCount.scoreCount) {
				ball.GetComponent<BallMovement> ().dir = new Vector2 (1, _randomY[i]);
				//Invocamos la función que permite spawnear la bola ya sea en el spawn de arriba o el de abajo
				Invoke ("BottomSpawn", 2);
				//apagamos el scoreCount para que no saque bolas de más y cambiamos de spawn
				rightCount.scoreCount = false;
				changeSpawn = false;
			}
			//Hacemos lo mismo pero esta vez a la izquierda, solo varia la dirección en la coordena 'X'
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
	//Crea la bola en el spawn de arriba
	void TopSpawn(){
		Instantiate (ball, spawn[0]);
	}
	//Crea la bola en el spawn de abajo
	void BottomSpawn(){
		Instantiate (ball, spawn[1]);
	}

	void RandomSpawn(){
		Instantiate (ball, spawn[i]);
	}

	public void GameEnd(){
		//Función para concluir el juego apagando los trigger de puntaje, las raquetas y reiniciamos el juego en unos segundos
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
