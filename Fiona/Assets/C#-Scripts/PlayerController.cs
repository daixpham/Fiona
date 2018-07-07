using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float max_speed = 3f ;
    [SerializeField] private float max_jumpPower = 8f;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float movement = 0f;
    public bool grounded;
    public bool w_pressed;
    GameObject Animation;
    Animator tmp;
    private float y; 
    // Use this for initialization
    void Start () {
        Animation = transform.GetChild(0).gameObject;
        tmp = Animation.GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
        float y_ = Animation.transform.rotation.y;
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

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
            if (Input.GetKey(KeyCode.W) && grounded && !w_pressed )
        {
            w_pressed = true;
            rigidBody.AddForce(new Vector2(0,10f), ForceMode2D.Impulse);
        }
        else
        {
            tmp.SetInteger("State", 0);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
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
