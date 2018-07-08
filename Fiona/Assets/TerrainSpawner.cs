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
    private float X, Y, Z;
    private bool oasis;
    private int sameLimit = 2;
    private int prevTile;
	// Use this for initialization
	void Start () {
        X = 0;
        Y = 180;
        Z = 0;
		createdList= new List<GameObject>();
		player = GameObject.FindGameObjectWithTag("Player");
		GameObject first = Instantiate (tileList [tileList.Length-1], new Vector3 (0,0, 0), Quaternion.Euler (X, Y, Z));
		first.transform.parent = map.transform;
		first.tag = "Ground";
		createdList.Add (first);
	}

	// Update is called once per frame
	void Update ()
    {
		if (GameSingelton.PlayerHealth > 0) {
			//GameSingelton.Instance.move= new Vector3(Time.deltaTime * 5f, 0, 0);
			foreach (GameObject tile in createdList) {
				tile.transform.Translate (GameSingelton.Instance.move);
                
			}
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
		GameObject obj = Instantiate (tileList [random], new Vector3 ((createdList[createdList.Count-1].transform.position.x+tileSize), 0, 0), Quaternion.Euler (X, Y, Z));
    //    GameObject obj = GameObject.Instantiate(tileList[random], new Vector3((createdList[createdList.Count - 1].transform.position.x + tileSize), 0, 0), Quaternion.Euler(270, 90, 0)) as GameObject;
    
        obj.transform.parent = map.transform;
		createdList.Add (obj);
		obj.tag = "Ground";
	}

}
