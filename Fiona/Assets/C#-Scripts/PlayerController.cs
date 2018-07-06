using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float max_speed = 3f ;
    [SerializeField] private float max_jumpPower = 3f;
    GameObject Animation;
    Animator tmp;
    // Use this for initialization
    void Start () {
        Animation = transform.GetChild(0).gameObject;
        tmp = Animation.GetComponent<Animator>();

        
	}
	
	// Update is called once per frame
	void Update () {
        
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * max_speed;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * max_jumpPower;

        transform.Translate(x, y, 0);
        Move(); 
    }

    void Move ()
    { // 
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.D) && Animation.transform.rotation.y != 0) {
                transform.Rotate(0, 0, 0);
                
            }
            tmp.SetInteger("State", 1);

        }
       else 
       if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKeyDown(KeyCode.A) && Animation.transform.rotation.y != -1) {
                transform.Rotate(0, 180, 0); }
               
            tmp.SetInteger("State", 1);
            
            
        }   
        else
        {
            tmp.SetInteger("State", 0);
        }

        Debug.Log(transform.rotation.y);
    }
}
