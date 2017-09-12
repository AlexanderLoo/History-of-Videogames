using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsController : MonoBehaviour {

	public GameObject[] enemies;
	public Transform[] spawns;
	public int hazardCount;
	public float spawnWait;
	//Mínimo y Máximo en coordenadas 'X' y 'Y' (uso vector2 para almacenar 2 valores)
	public Vector2 positionInX, positionInY;

	void Start(){
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves(){

		yield return new WaitForSeconds (1);

		while (true) {
			//Con hazardCount controlamos el número de asteroides que se crea por oleada por los 4 lados
			for (int i = 0; i < hazardCount; i++) {
				TopBottomSpawns ();
				LeftRigthSpawns ();
			}
			//Tiempo de espera para la siguiente oleada
			yield return new WaitForSeconds (spawnWait);
		}
	}

	void TopBottomSpawns(){
		//Se recorre los spawns de arriba y de abajo, por cada spawn se crea un asteroide con coordenada 'X' aleatoria(dentro del rango de pantalla en 'X')
		for (int i = 0; i < 2; i++) {
			Vector3 newPosition = spawns [i].position;
			newPosition.x = Random.Range (positionInX.x,positionInX.y);
			spawns [i].position = newPosition;
			//Rotación aleatoria para que se vayan en cualquier dirección e Instanciamos un enemigo aleatorio(tamaño y tipo)
			Quaternion newQuaternion = Quaternion.Euler (0, 0, Random.Range (0, 360));
			Instantiate (enemies [Random.Range (0, enemies.Length)], spawns [i].position, newQuaternion);
		}
	}

	void LeftRigthSpawns(){
		//Lo mismo que el código anterior pero esta vez con los spawns izquierda y derecha
		for (int i = 2; i < 4; i++) {
			Vector3 newPosition = spawns [i].position;
			newPosition.y = Random.Range (positionInY.x,positionInY.y);
			spawns [i].position = newPosition;
			Quaternion newQuaternion = Quaternion.Euler (0, 0, Random.Range (0, 360));
			Instantiate (enemies [Random.Range (0, enemies.Length)], spawns [i].position, newQuaternion);
		}
	}
}
