using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour {

	public int vida;
	MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
		meshRenderer = gameObject.GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hurt()
	{
		StartCoroutine (HurtFlash ());
		vida--;
		if (vida <= 0) {
			Destroy (gameObject);
		}
	}

	IEnumerator HurtFlash()
	{
		meshRenderer.material.color = Color.red;
		yield return new WaitForSeconds (0.1f);
		meshRenderer.material.color = Color.white;
	}
}
