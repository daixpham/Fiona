using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class TestAnimationScript : MonoBehaviour
{

    private bool _running;
    private bool _jumping;
    private bool _landing;
    private bool _dead;
    private bool _crouch;
    private bool grounded = true;
    private bool w_pressed;
    private int jump_count = 0;
    public Animator controller;
    public Rigidbody rigidBody;
    GameObject cameraObj;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        cameraObj = transform.GetChild(11).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameSingelton.PlayerHealth > 0)
        {
            controller.SetBool("IsRunning", true);
            Debug.Log("W Pressed" + w_pressed + "  " + grounded);
            if (Input.GetKeyDown(KeyCode.W) && !w_pressed && grounded)
            {
                grounded = false;
                controller.SetBool("IsJumping", true);
                controller.SetBool("IsRunning", false);
                rigidBody.AddForce(new Vector3(0, 20f, 0), ForceMode.Impulse);


            }

            if (grounded == true)
            {
                controller.SetBool("IsJumping", false);
                controller.SetBool("InLanding", false);


            }

            if (_jumping == true)
            {

                w_pressed = true;

            }

        }
        else
        {
            controller.SetBool("IsRunning", false);
            cameraObj.transform.parent = transform.parent;
            if (transform.localScale.x > 0)
                transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        }


    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;

            controller.SetBool("InLanding", false);

        }

        Debug.Log("OnColi" + collision.gameObject.tag);
    }


}