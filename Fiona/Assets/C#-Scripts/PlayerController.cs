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
	void Update ()
    {
        if (GameSingelton.PlayerHealth > 0)
        {
            float jump = Input.GetAxis("Vertical");
            float y_ = Animation.transform.rotation.y;
            tmp.SetInteger("State", 1);

            
			if (jump != 0 && grounded && !w_pressed)
            {
				w_pressed = true;
				rigidBody.AddForce (new Vector3 (0, max_jumpPower, 0), ForceMode.Impulse);
			}
        

			if (jump == 0)
            {
				w_pressed = false;
			}
		} 
		else {
			tmp.SetInteger ("State", 0);
		}
    }

    private void OnCollisionEnter(Collision collision)
    {
       // print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
        }

        if (collision.gameObject.tag == "CollisionObject")
        {
            GameSingelton.Instance.move = new Vector3(0,0,0);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "CollisionObject")
        {
            print(collision.gameObject.name);
            GameSingelton.Instance.move = new Vector3(GameSingelton.SPEED,0,0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Oasis")
        {
            GameSingelton.Instance.RestoreHealth(10f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Oasis")
        {
            GameSingelton.Instance.RestoreHealth(10f);
        }
    }

}
