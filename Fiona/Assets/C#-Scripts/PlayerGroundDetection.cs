using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetection : MonoBehaviour {

    public TestAnimationScript pcontrol;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        // print(collision.gameObject.tag);
        if (other.gameObject.tag == "Ground")
        {
            pcontrol.grounded = true;
        }
        if (other.gameObject.tag == "CollisionObject")
        {
            GameSingelton.Instance.move = new Vector3(GameSingelton.SPEED, 0, 0);
        }


        /*if (other.gameObject.tag == "CollisionObject")
        {
            GameSingelton.Instance.move = new Vector3(0, 0, 0);
        }*/
    }

    private void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "Ground" /*|| collision.gameObject.tag == "CollisionObject"*/)
        {
            pcontrol.grounded = false;
        }


    }
}
