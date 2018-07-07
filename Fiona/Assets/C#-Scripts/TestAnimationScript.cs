using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class TestAnimationScript : MonoBehaviour {

    private bool _running;
    private bool _jumping;
    private bool _landing;
    private bool _dead;
    private bool _crouch;
    private bool grounded;
    private bool w_pressed;
    public Animator controller;
    public Rigidbody rigidBody;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyUp(KeyCode.D))
        {
            _running = !_running;
            controller.SetBool("IsRunning", _running);
        }


        if (Input.GetKeyDown(KeyCode.W) && !w_pressed)
        {
            
            controller.SetBool("IsJumping", true);
            
            rigidBody.AddForce(new Vector3(0, 3f,0), ForceMode.Impulse);
         
            if (grounded == true )
            {
                controller.SetBool("IsJumping", false);
                controller.SetBool("InLanding", false);

            }
        }

        if (_jumping == true)
        {
            w_pressed = false;
        }

    }

  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            
            controller.SetBool("InLanding", true);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
            _jumping = false;

        }
    }
}
