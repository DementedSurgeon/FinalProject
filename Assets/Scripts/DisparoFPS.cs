using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoFPS : MonoBehaviour {

	public ParticleSystem particleSys;
	public ParticleSystem sparksPrefab;

	public Camera playerCam;
	public float cooldownTime;
	private float cooldown;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
		}
		if (Input.GetMouseButton (0)) {
			if (cooldown <= 0) {
				particleSys.Play ();
				RaycastHit hit;
				if (Physics.Raycast (playerCam.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0)), out hit, 50)) {
					Debug.Log ("Hit!");
					Instantiate (sparksPrefab, hit.point, Quaternion.identity);
					if (hit.collider.tag == "Enemy") {
						hit.collider.GetComponent<Vida> ().Hurt ();
					}
				} else {
					Debug.Log ("Miss!");
				}
				cooldown = cooldownTime;
			}
		}
	}
}
