using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameSingelton.PlayerHealth > 0) {
			float x = Time.deltaTime * 20f;
			transform.Translate (-x, 0, 0);

			if (transform.position.x < -40 || transform.position.y < -40) {
				Destroy (this.gameObject);
			}
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{
        //    print("AAAAAAAAAAAAAAAAAAAA");
        //}
    }
}
