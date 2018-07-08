﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	[SerializeField] GameObject[] enemyObjects;
	[SerializeField] GameObject map;
	[SerializeField] GameObject player;
	[SerializeField] float minSpawnRate=2.5f;
	[SerializeField] float maxSpawnRate=1f;
	private float secs ;
	// Use this for initialization
	void Start () {
		float random = Random.Range (maxSpawnRate, minSpawnRate);
		secs = random;
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		if (x != 0) {
			
			if (secs > 0) {
				secs -= Time.deltaTime;
			} else {
				float random = Random.Range (maxSpawnRate, minSpawnRate);
				secs = random;
				int randomObject = (int)Random.Range (0, enemyObjects.Length);
				random = Random.Range (40, 80);
				float randomZ = Random.Range (-4f, 4f);
				GameObject obj = Instantiate (enemyObjects [randomObject], new Vector3 ((player.transform.position.x + random), 12, randomZ), Quaternion.Euler (0, 0, 0));
				obj.transform.parent = transform;
			}
		}
	}
}
