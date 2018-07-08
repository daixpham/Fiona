using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	[SerializeField] GameObject[] enemyObjects;
	[SerializeField] GameObject map;
	[SerializeField] GameObject player;
	[SerializeField] float minSpawnRate=3.5f;
    [SerializeField] float maxSpawnRate = 6f;
    [SerializeField] float waterspawn= 1.5f;
    const float SPAWN_DISTANCE = 60f;
	private float secs ;
	// Use this for initialization
	void Start () {
		float random = Random.Range (maxSpawnRate, minSpawnRate);
		secs = random;
        print(enemyObjects.Length);
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
        float random = Random.Range(maxSpawnRate, minSpawnRate);
        if (x != 0) {
			
			if (secs > 0) {
				secs -= Time.deltaTime;
                waterspawn -= Time.deltaTime;

            } else {
				secs = random;
				int randomObject = (int)Random.Range (0, enemyObjects.Length-2);
                waterspawn = 1.5f;
                GameObject obj2 = new GameObject();
                GameObject obj = Instantiate (enemyObjects [4], new Vector3 ((player.transform.position.x + SPAWN_DISTANCE), 4, 0), Quaternion.Euler (0, 0, 0));
                print(randomObject);
                print(randomObject > (enemyObjects.Length / 2));
                if (randomObject> (enemyObjects.Length/2)-1)
                    obj2 = Instantiate(enemyObjects[enemyObjects.Length - 1], new Vector3((player.transform.position.x + SPAWN_DISTANCE-9), 4, 0), Quaternion.Euler(0, 0, 0));
                obj.transform.parent = transform;
                obj2.transform.parent = transform;
		     }
        }
	}
}
