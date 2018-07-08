using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandstormCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
