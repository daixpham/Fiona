using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn : MonoBehaviour {

	[SerializeField] GameObject waterDrop;
	[SerializeField] GameObject map;
	[SerializeField] GameObject player;
	[SerializeField] float spawnRate=2.5f;
	private float secs ;

	// Use this for initialization
	void Start () {
		secs = spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
			if (secs > 0) {
				secs -= Time.deltaTime;
			} else if (GameSingelton.Instance.move.x > 0 && GameSingelton.PlayerHealth>0)
            {
				secs = spawnRate;
				GameObject obj =Instantiate (waterDrop, new Vector3 ((player.transform.position.x + 40),12, 0 ), Quaternion.Euler (270,0,0));
				obj.transform.parent = transform;
			}
	}

	void initialize(){
	}
}
