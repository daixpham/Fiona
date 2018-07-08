using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandstormCollider : MonoBehaviour {


    public float VelocityX { get; set; }

    private bool inSandstorm;
    // Use this for initialization
    void Start()
    {
        inSandstorm = false;
        VelocityX = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 tmp = transform.position;
        if (GameSingelton.Instance.move.x > 0)
        {
            tmp.x = 0;
        }
        else
        {
            tmp.x += VelocityX;
            transform.position = (tmp);
        }
    }

	private void OnTriggerStay(Collider collision)
	{
		
		if (collision.gameObject.tag == "Player")
		{
			GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();
			GameSingelton.Instance.DrainHealth();

		}

	}
}
