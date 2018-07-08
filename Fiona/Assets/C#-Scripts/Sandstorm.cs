using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandstorm : MonoBehaviour
{

    public float VelocityX { get; set; }

    private bool inSandstorm;
    // Use this for initialization
    void Start()
    {
        inSandstorm = false;
        VelocityX = 0.1f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 tmp = transform.position;
        if (GameSingelton.Instance.move.x >= 0)
        {
            tmp.x += VelocityX;
        }
        else
        {
            tmp = Vector3.zero;
        }
        transform.position = (tmp);
        if (inSandstorm)
        {
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
        }
    }
}
