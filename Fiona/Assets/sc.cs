using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour {

	[SerializeField] private GameObject player;
	[SerializeField] private float maxSpeed = 100f;
	[SerializeField] private float maxJumpHeight = 100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * maxSpeed;
		var y = Input.GetAxis ("Vertical") * Time.deltaTime * maxJumpHeight;

		transform.Translate (x, y, 0);
	}
}
