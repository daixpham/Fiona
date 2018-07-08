using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class RockSpawn : MonoBehaviour {

    // Use this for initialization
    [SerializeField] GameObject dropRock;
    [SerializeField] GameObject map;
    [SerializeField] GameObject player;
    [SerializeField] float spawnRate = 2.5f;
    private float secs;

    void Start () {
        secs = spawnRate;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (secs > 0)
        {
            secs -= Time.deltaTime;
        }
        else
        {
            secs = spawnRate;
            
            GameObject obj = Instantiate(dropRock, new Vector3((player.transform.position.x + UnityEngine.Random.Range(20f, 40f)), UnityEngine.Random.Range(2f, 4f), 0.5f), Quaternion.Euler(270, 0, 0));
            obj.transform.parent = transform;
        }
    }
    void initialize()
    {
    }
}
