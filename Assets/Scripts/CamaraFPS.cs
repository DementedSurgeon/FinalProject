using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFPS : MonoBehaviour {

	float mouseY;
	float mouseSensibility;
	float cameraRotX;

	// Use this for initialization
	void Start () {
		cameraRotX = transform.localRotation.eulerAngles.x;
	}
	
	// Update is called once per frame
	void Update () {
		mouseY = -Input.GetAxis ("Mouse Y");
		cameraRotX += mouseY * mouseSensibility;
		cameraRotX = Mathf.Clamp (cameraRotX, -90, 90);
		Quaternion rotation = Quaternion.Euler(cameraRotX, transform.localRotation.y, transform.localRotation.z);
		transform.localRotation = rotation;
		Debug.Log (transform.localEulerAngles.x);
	}

	public void SetSensibility(float newSensibility)
	{
		mouseSensibility = newSensibility;
	}


}
