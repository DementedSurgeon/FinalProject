using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {

	public Bullet prefab;
	public int turretNumber;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < turretNumber * prefab.lifespan; i++) {
			Instantiate (prefab, transform.position, Quaternion.identity, transform);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
