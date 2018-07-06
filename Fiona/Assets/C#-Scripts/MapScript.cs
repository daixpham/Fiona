using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour {
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject grid;
	[SerializeField] private GameObject[] tiles;
	[SerializeField] private int tileSize=40;
	private List<GameObject> tileList;
	private int currentTilePos=1;
	private int playerTilePos=0;
	private int totalTileCount=0;

	[SerializeField] private int numOfSeconds=10;
	private float secs;

	void Start () {
		secs = numOfSeconds;

		tileList= new List<GameObject>();
		addTile ();
	}
	
	// Update is called once per frame
	void Update () {
		playerTilePos = (int)(player.transform.position.x / 39);


		if ((totalTileCount -playerTilePos)<2) {
			addTile ();
		} 
		else if(40*(playerTilePos -3) > tileList[0].transform.position.x){
			GameObject tmp = tileList [0];
			Destroy (tmp);
			tileList.RemoveAt (0);
		}
			
	}

	void addTile(){
		totalTileCount++;
		int random = (int)Random.Range (0, tiles.Length);
		GameObject firstTile = Instantiate (tiles [random], new Vector3 (currentTilePos*tileSize, 0, 0), Quaternion.identity);
		firstTile.transform.parent = grid.transform;
		tileList.Add (firstTile);
		currentTilePos++;
	}
}
