using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandstormCollider : MonoBehaviour {


    public float VelocityX { get; set; }
    private float startPositionX;
    private float DrainSpeed;
    // Use this for initialization
    void Start()
    {
        startPositionX = transform.position.x;
        VelocityX = GameSingelton.sandstormSpeed;
        DrainSpeed = GameSingelton.DrainSpeedSandstrom;
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
        if (GameSingelton.PlayerHealth >= (GameSingelton.PlayerMaxHealth*0.9f))
        {
            SetPosition();
        }
    }

	private void OnTriggerStay(Collider collision)
	{
		
		if (collision.gameObject.tag == "Player")
		{
			GameSingelton.Instance.DrainHealth(DrainSpeed);
		}

	}

    public void SetPosition()
    {
        if (startPositionX < transform.position.x)
        {
            //Debug.Log(transform.position.x);
            Vector3 tmp = transform.position;
            tmp.x -= 0.04f;
            if (tmp.x < startPositionX)
                tmp.x = startPositionX;
            transform.position = tmp;
        }
    }
}
