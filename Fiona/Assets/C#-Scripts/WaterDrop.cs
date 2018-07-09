using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour {
    public static float WaterRegen;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
        float tmp = GameSingelton.SPEED;
		if (GameSingelton.PlayerHealth > 0 && GameSingelton.Instance.move.x>0) {
            float x = tmp;//Time.deltaTime * 10*tmp;
			transform.Translate (-x, 0, 0);

			if (transform.position.x < -40 || transform.position.y < -40) {
				Destroy (this.gameObject);
			}
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
//        if (collision.gameObject.tag == "Player")
//        {
////            print(collision.gameObject.name);
//            GameSingelton.Instance.RestoreHealth(20f);
//            Object.Destroy(this.gameObject);
//			int numPoints = 10;
//			for(int i=0;i < numPoints;i++)
//				GameSingelton.Instance.UpdateScore ();
//         }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameSingelton.Instance.RestoreHealth(WaterRegen);
            Object.Destroy(this.gameObject);
            int numPoints = 10;
            for (int i = 0; i < numPoints; i++)
                GameSingelton.Instance.UpdateScore();
        }

    }
}
