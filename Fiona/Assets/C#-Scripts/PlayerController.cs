using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float max_speed = 3f ;
    [SerializeField] private float max_jumpPower = 3f;
    [SerializeField] private GameObject player;
    GameObject Animation;
    Animator tmp;
    private float x;
    private float y; 
    // Use this for initialization
    void Start () {
        Animation = transform.GetChild(0).gameObject;
        tmp = Animation.GetComponent<Animator>();

        
	}
	
	// Update is called once per frame
	void Update () {
        
        float y_ = player.transform.rotation.y;
        if (Input.GetKey(KeyCode.D))
        {
            
           
            if (player.transform.rotation.y ==1)
            {
                transform.Rotate(0, 180, 0);
                
            }

            tmp.SetInteger("State", 1);

        }
        else
      if (Input.GetKey(KeyCode.A))
        {
           
            if (player.transform.rotation.y != 1)
            {
              
                
                transform.Rotate(0, 180, 0);
                
            }

            tmp.SetInteger("State", 1);


        }
        else
        {
            tmp.SetInteger("State", 0);
        }
    }

   
}
