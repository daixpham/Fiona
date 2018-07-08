using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float y = Input.GetAxis ("Vertical") * Time.deltaTime * 200f;
		if (y > 0) {
			transform.Translate (0, y, 0);
		}
	}
}
