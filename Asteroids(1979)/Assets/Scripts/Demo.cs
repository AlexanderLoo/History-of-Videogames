using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour {

	public GameObject[] enemies;
	public Transform[] spawns;
	public float spawnWait;
	public Vector2 positionInX, positionInY;

	void Start(){
		StartCoroutine (SpawnWaves ());
	}


	IEnumerator SpawnWaves(){

		while (true) {

			for (int i = 0; i < 2; i++) {
				TopBottomSpawns ();
				LeftRigthSpawns ();
			}
			yield return new WaitForSeconds (spawnWait);
		}
	}
	void TopBottomSpawns(){

		for (int i = 0; i < 2; i++) {
			Vector3 newPosition = spawns [i].position;
			newPosition.x = Random.Range (positionInX.x, positionInX.y);
			spawns [i].position = newPosition;
			Quaternion newQuaternion = Quaternion.Euler (0, 0, Random.Range (0, 360));
			Instantiate (enemies [Random.Range (0, enemies.Length)], spawns [i].position, newQuaternion);
		}
	}
	void LeftRigthSpawns(){

		for (int i = 2; i < 4; i++) {
			Vector3 newPosition = spawns [i].position;
			newPosition.y = Random.Range (positionInY.x, positionInY.y);
			spawns [i].position = newPosition;
			Quaternion newQuaternion = Quaternion.Euler (0, 0, Random.Range (0, 360));
			Instantiate (enemies [Random.Range (0, enemies.Length)], spawns [i].position, newQuaternion);
		}
	}
}