using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn : MonoBehaviour {

	[SerializeField] GameObject waterDrop;
	[SerializeField] GameObject map;
	[SerializeField] GameObject player;
	private float spawnRate=GameSingelton.spawnSpeed;
	private float secs ;

	// Use this for initialization
	void Start () {
        secs = 0;

	}
    

    private void FixedUpdate()
    {
        if (secs > 0 && GameSingelton.Instance.move.x > 0)
        {
            secs -= Time.deltaTime;
        }
        else if (GameSingelton.Instance.move.x > 0 && GameSingelton.PlayerHealth > 0)
        {

            secs = spawnRate;
            GameObject obj = Instantiate(waterDrop, new Vector3((player.transform.position.x + 20), 3, 0), Quaternion.Euler(270, 0, 0));
            obj.transform.parent = transform;
            Debug.Log(secs);
        }
    
    }

	void initialize(){
	}
}
