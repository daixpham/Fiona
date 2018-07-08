using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TestAnimationScript : MonoBehaviour {

	private bool _running;
	private bool _jumping;
	private bool _landing;
	private bool _dead;
	private bool _crouch;
	public bool grounded=false;
	private bool w_pressed;
    private int jump_count = 0;
	public Animator controller;
	public Rigidbody rigidBody;
    GameObject cameraObj;
    // Use this for initialization
    void Start () {
		rigidBody = GetComponent<Rigidbody>();
        cameraObj = transform.GetChild(11).gameObject;
    }

	// Update is called once per frame
	void Update () {

        if (rigidBody.velocity.y <= 0)
        {
            controller.SetBool("IsFalling", true);
            controller.SetBool("IsJumping", false);
        }
        else
        {
            controller.SetBool("IsFalling", false);
        }


        if(grounded)
        {
            controller.SetBool("InLanding", true);
        }
        else
        {
            controller.SetBool("InLanding", false);
        }
       
        if (GameSingelton.PlayerHealth > 0)
        {
            Debug.Log("Grounded" + grounded);

            controller.SetBool("IsRunning", true);
            if (Input.GetKeyDown(KeyCode.W) && grounded )
            {
                
                controller.SetBool("IsJumping", true);
                //controller.SetBool("IsRunning", false);
                rigidBody.AddForce(new Vector3(0, 20f, 0), ForceMode.Impulse);


            }
           


            if (_jumping == true)
            {
           
                w_pressed = true;

            }
            
        }else
        {
            controller.SetBool("IsRunning", false);
            cameraObj.transform.parent = transform.parent;
            if (transform.localScale.x>0)
            transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        }


	}



	private void OnCollisionEnter(Collision collision)
	{
		/*if (collision.gameObject.tag == "Ground"|| collision.gameObject.tag == "CollisionObject")
		{
			grounded = true;

			

		}*/

       
	}

    private void OnCollisionExit(Collision collision)
    {
        /*if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "CollisionObject")
        {
            grounded = false;



        }*/


    }
}