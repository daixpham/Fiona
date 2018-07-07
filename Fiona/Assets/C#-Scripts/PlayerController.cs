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
		float z = Input.GetAxis ("Vertical") * Time.deltaTime * 100f;
		transform.Translate (0, z, 0);
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
    }

   
}
