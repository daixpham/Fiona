using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour {

	[SerializeField] private float maxSpeed = 100f;


	[SerializeField] private GameObject player;
	[SerializeField] private GameObject map;
	[SerializeField] private GameObject[] tiles;
	[SerializeField] private GameObject[] OasisTiles;
	[SerializeField] private int tileSize=40;
	private List<GameObject> tileList;
	private int currentTilePos=0;
	private float playerPos;
	private int totalTileCount=0;
	private int collision=0;		// 0- no collision 1-right 2-left
	private float fieldOfView;


	void Start () {
		playerPos = (player.transform.position.x);
		tileList= new List<GameObject>();
		initialize ();
		GameObject playerCam = GameObject.FindGameObjectWithTag("PlayerCamera");
		Camera tmp = playerCam.GetComponent<Camera> ();
		fieldOfView = tmp.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal") * Time.deltaTime * maxSpeed;
		if (collision == 1) {
			if(x<0)
				foreach (GameObject tile in tileList) {
					tile.transform.Translate (-x, 0, 0);
				}
		} 
		else if (collision == 2) {
			
			if(x>0)
				foreach (GameObject tile in tileList) {
					tile.transform.Translate (-x, 0, 0);
				}
		} 
		else {
			foreach (GameObject tile in tileList) {
				tile.transform.Translate (-x, 0, 0);
			}
		}






		if (tileList [0].transform.position.x < ((player.transform.position.x) - tileSize * 2)-fieldOfView) {
			Destroy (tileList [0]);
			tileList.RemoveAt (0);
		} 
		else if (tileList [tileList.Count - 1].transform.position.x < playerPos + tileSize) {
			addTile ();
		}
	}

	void initialize(){
		totalTileCount++;
		int random = (int)Random.Range (0, OasisTiles.Length-1);
		GameObject firstTile = Instantiate (OasisTiles [1], new Vector3 (currentTilePos*tileSize, 0, 0), Quaternion.identity);
		firstTile.transform.parent = map.transform;
		tileList.Add (firstTile);

		firstTile = Instantiate (OasisTiles [random], new Vector3 ((tileList[tileList.Count-1].transform.position.x+tileSize), 0, 0), Quaternion.identity);
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



	public void getCollisionHeight(float collisionHeight, bool right){
		
		float playerHeight= (player.transform.position.y);
		if (collisionHeight - (playerHeight - 2) > 1) {
			if (right)
				collision = 1;
			else
				collision = 2;
			return;
		}
		else if (collisionHeight - (playerHeight - 2) <= 1 && collisionHeight - (playerHeight - 2) > 0.5) {
			Vector3 pos = player.transform.position;
			pos.y += 1;
			player.transform.position = pos;
		}
		collision = 0;
	}

	public void exitCollision(){
		collision = 0;
	}
}
