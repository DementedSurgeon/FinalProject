using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public float lifespan;
	private float lifespanTimer;

	void OnEnable(){
		lifespanTimer = lifespan;
		StartCoroutine (Advance ());
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Advance(){
		while (gameObject.activeSelf){
			transform.position += transform.forward * speed * Time.deltaTime;
			lifespanTimer -= Time.deltaTime;
			if (lifespanTimer <= 0) {
				gameObject.SetActive (false);
			}
			yield return null;
		}
	}

	void OnCollisionEnter(Collision col){
		gameObject.SetActive (false);
	}
}
