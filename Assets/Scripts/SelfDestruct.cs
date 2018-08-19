using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	public float lifetime;

	// Use this for initialization
	void Start () {
		StartCoroutine (Implode ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Implode()
	{
		yield return new WaitForSeconds (lifetime);
		Destroy (gameObject);
	}
}
