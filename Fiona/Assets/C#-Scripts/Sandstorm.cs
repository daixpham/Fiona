using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandstorm : MonoBehaviour
{

    public float VelocityY { get; set; }
    private Vector3 VectorVelocity;
    private bool inSandstorm;
    // Use this for initialization
    void Start ()
    {
        inSandstorm = false;
        VelocityY = 0.0001f;
        if (GameSingelton.start)
        {
 //           VectorVelocity = new Vector3(0, VelocityY, 0);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 tmp = gameObject.transform.position + VectorVelocity;
        this.gameObject.transform.Translate(tmp);
        if (inSandstorm)
        {
            GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();

        }

	}
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inSandstorm = true;
            Destroy(collision.gameObject);
        }
    }
}
