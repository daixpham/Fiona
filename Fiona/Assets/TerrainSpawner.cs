using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour {
	[SerializeField] GameObject[] tileList;
	[SerializeField] GameObject map;
	private List<GameObject> createdList;
	private GameObject player;
	private int playerTile;
	private float tileSize=58;
	// Use this for initialization
	void Start () {
		createdList= new List<GameObject>();
		player = GameObject.FindGameObjectWithTag("Player");
		GameObject first = Instantiate (tileList [0], new Vector3 (0, 0, 0), Quaternion.Euler (270,90,0));
		first.transform.parent = map.transform;
		first.tag = "Ground";
		createdList.Add (first);
	}

	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal") * Time.deltaTime * 20f;
		foreach (GameObject tile in createdList) {
			tile.transform.Translate (0, x, 0);
		}
		if (createdList [0].transform.position.x < ((player.transform.position.x) - tileSize*2 )) {
			Destroy (createdList [0]);
			createdList.RemoveAt (0);
		} 
		else if (createdList [createdList.Count - 1].transform.position.x < (player.transform.position.x) + tileSize) {
			addTile ();
		}
	}

	void addTile(){
		int random = (int)Random.Range (0, tileList.Length);
        GameObject obj = GameObject.Instantiate(tileList[random], new Vector3((createdList[createdList.Count - 1].transform.position.x + tileSize), 0, 0), Quaternion.Euler(270, 90, 0)) as GameObject;
    
        obj.transform.parent = map.transform;
		createdList.Add (obj);
		obj.tag = "Ground";
	}

}
