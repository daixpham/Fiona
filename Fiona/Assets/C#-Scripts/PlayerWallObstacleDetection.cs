using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallObstacleDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        // print(collision.gameObject.tag);
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "CollisionObject")
        {
            GameSingelton.Instance.move = new Vector3(0, 0, 0);
            Debug.Log("Lol Wall, lol Collision: " + other.gameObject.tag);
        }

    }

    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "CollisionObject")
        {
            GameSingelton.Instance.move = new Vector3(GameSingelton.SPEED, 0, 0);
            Debug.Log("Lol Wall, lol Collision ENDED: " + collision.gameObject.tag);
        }


    }
}
