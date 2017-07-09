using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFlash : MonoBehaviour {

	private Camera _camera;
	public bool gameStart;

	void Start(){

		_camera = GetComponent<Camera> ();
	}
	public void Flash(){

		Color newColor = _camera.backgroundColor;
		newColor.r = Mathf.Lerp (newColor.r, 1,Time.deltaTime * 10);
		newColor.g = Mathf.Lerp (newColor.g, 1,Time.deltaTime * 10);
		newColor.b = Mathf.Lerp (newColor.b, 1,Time.deltaTime * 10);
		_camera.backgroundColor = newColor;
		Invoke ("FlashOff", 0.2f);
	}

	void FlashOff(){

		Color newColor = _camera.backgroundColor;
		newColor.r = Mathf.Lerp (newColor.r, 0,Time.deltaTime * 21);
		newColor.g = Mathf.Lerp (newColor.g, 0,Time.deltaTime * 21);
		newColor.b = Mathf.Lerp (newColor.b, 0,Time.deltaTime * 21);
		_camera.backgroundColor = newColor;
		gameStart = false;
	}
}
