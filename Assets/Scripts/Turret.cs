using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public float fireTimer;
	public GameObject bulletPool;
	private float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0) {
			Fire (FindAvailableProjectile (bulletPool));
		}
	}

	GameObject FindAvailableProjectile(GameObject pool){
		for (int i = 0; i < pool.transform.childCount; i++) {
			if (!pool.transform.GetChild (i).gameObject.activeSelf) {
				return pool.transform.GetChild (i).gameObject;
			}
		}
		return null;
	}

	void Fire(GameObject bullet){
		if (bullet != null) {
			bullet.SetActive (true);
			bullet.transform.position = transform.position;
			bullet.transform.rotation = transform.rotation;
			timer = fireTimer;
		}
	}
}
