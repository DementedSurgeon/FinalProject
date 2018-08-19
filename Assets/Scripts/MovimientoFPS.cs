using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFPS : MonoBehaviour {

	//GameObject fpsCamera;
	CharacterController characterController;

	public float movementSpeed;
	private float walkSpeed;
	private float sprintSpeed;

	public float mouseSensibility;
	public float gravity = 2;
	private float oldSensibility;
	private Vector3 gravityVector;

	// Use this for initialization
	void Start () {
		walkSpeed = movementSpeed;
		sprintSpeed = movementSpeed * 2;
		characterController = gameObject.GetComponent<CharacterController> ();
		gravityVector = new Vector3(0, -gravity, 0);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			movementSpeed = sprintSpeed;
		} else if (Input.GetKeyUp (KeyCode.LeftShift)) {
			movementSpeed = walkSpeed;
		}

		Vector3 movement = (transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical")) + gravityVector;
		characterController.Move (movement * Time.deltaTime * movementSpeed);

		float mouseX = Input.GetAxis ("Mouse X");
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + mouseX * mouseSensibility, transform.eulerAngles.z); 

		if (Input.GetKeyDown (KeyCode.Space) && characterController.isGrounded) {
			StartCoroutine (Jump ());
		}

		if (oldSensibility != mouseSensibility) {
			UpdateSensibility ();
		}
		oldSensibility = mouseSensibility;
	}

	void UpdateSensibility()
	{
		transform.GetComponentInChildren<CamaraFPS> ().SetSensibility (mouseSensibility);

	}

	IEnumerator Jump()
	{
		gravityVector = -gravityVector;
		yield return new WaitForSeconds (0.5f);
		gravityVector = -gravityVector;
	}
}
