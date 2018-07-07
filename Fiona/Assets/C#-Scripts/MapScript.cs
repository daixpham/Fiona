using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour {
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject map;
	[SerializeField] private GameObject[] tiles;
	[SerializeField] private GameObject[] OasisTiles;
	[SerializeField] private int tileSize=40;
	private List<GameObject> tileList;
	private int currentTilePos=0;
	private float playerPos;
	private int totalTileCount=0;

	[SerializeField] private int numOfSeconds=10;
	private float secs;

	void Start () {
		secs = numOfSeconds;
		playerPos = (player.transform.position.x);
		tileList= new List<GameObject>();
		initialize ();

	}
	
	// Update is called once per frame
	void Update () {
		if (tileList [0].transform.position.x < playerPos - tileSize * 2) {
			Destroy (tileList [0]);
			tileList.RemoveAt (0);
		} 
		else if (tileList [tileList.Count - 1].transform.position.x < playerPos + tileSize) {
			addTile ();
			Debug.Log (playerPos + tileSize);
		}
	}

	void initialize(){
		totalTileCount++;
		int random = (int)Random.Range (0, OasisTiles.Length-1);
		GameObject firstTile = Instantiate (OasisTiles [0], new Vector3 (currentTilePos*tileSize, 0, 0), Quaternion.identity);
		firstTile.transform.parent = map.transform;
		tileList.Add (firstTile);

		firstTile = Instantiate (OasisTiles [1], new Vector3 (currentTilePos*tileSize, 0, 0), Quaternion.identity);
		firstTile.transform.parent = map.transform;
		tileList.Add (firstTile);

		currentTilePos++;
	}

	void addTile(){
		totalTileCount++;
		int random = (int)Random.Range (0, tiles.Length);
		GameObject firstTile = Instantiate (tiles [random], new Vector3 ((tileList[tileList.Count-1].transform.position.x+tileSize), 0, 0), Quaternion.identity);
		firstTile.transform.parent = map.transform;
		tileList.Add (firstTile);
		currentTilePos++;
	}
}
