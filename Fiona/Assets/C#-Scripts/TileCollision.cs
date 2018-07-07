using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollision : MonoBehaviour {
	GameObject parent;
	// Use this for initialization
	void Start () {
		parent = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D collision){
	}

	void OnCollisionExit2D(Collision2D collision){
		parent.GetComponent<MapScript> ().exitCollision ();

	}

	void OnCollisionStay2D(Collision2D collision){
		if (collision.collider.tag == "Player") {
			Vector3 contact = collision.contacts [0].point;
			foreach (ContactPoint2D tmp in collision.contacts) {
				if (tmp.point.y > contact.y) {
					contact = tmp.point;
				}
			}
			Vector3 center = collision.collider.bounds.center;
			bool right = center.x < contact.x;
			parent.GetComponent<MapScript> ().getCollisionHeight (contact.y,right);

		}
	}
}
