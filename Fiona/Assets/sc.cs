using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour {

	[SerializeField] private float maxSpeed = 100f;
	[SerializeField] private float maxJumpHeight = 100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal") * Time.deltaTime * maxSpeed;
		transform.Translate (x, 0, 0);
	}
}
