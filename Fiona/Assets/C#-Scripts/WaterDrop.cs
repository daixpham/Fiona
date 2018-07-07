using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            print(collision.gameObject.name);
            Object.Destroy(this.gameObject);
            GameSingelton.Instance.RestoreHealth(2f);
        }


    }
}
