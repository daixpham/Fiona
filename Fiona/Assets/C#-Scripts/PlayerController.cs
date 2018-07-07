using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float max_speed = 3f ;
    [SerializeField] private float max_jumpPower = 8f;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float movement = 0f;
    public bool grounded=true;
    public bool w_pressed;
    GameObject Animation;
    Animator tmp;
    private float y; 
    // Use this for initialization
    void Start () {
        Animation = transform.GetChild(0).gameObject;
        tmp = Animation.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {
		float jump = Input.GetAxis ("Vertical");
		float y_ = Animation.transform.rotation.y;
        if (Input.GetKey(KeyCode.D))
        {
            
           
			if (Animation.transform.rotation.y ==1)
            {
                Animation.transform.Rotate(0, 180, 0);
                
            }

            tmp.SetInteger("State", 1);

        }
        else
      if (Input.GetKey(KeyCode.A))
        {
           
			if (Animation.transform.rotation.y != 1)
            {
              
                Animation.transform.Rotate(0, 180, 0);
                
            }

            tmp.SetInteger("State", 1);


        }
		else
		{
				tmp.SetInteger("State", 0);

		}
		
        if (jump!=0 && grounded && !w_pressed )
        {
			w_pressed = true;
			rigidBody.AddForce(new Vector3(0,max_jumpPower,0), ForceMode.Impulse);
        }
        

		if (jump == 0) {
			w_pressed = false;
		}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
		
}
