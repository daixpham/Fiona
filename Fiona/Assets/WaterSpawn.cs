using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn : MonoBehaviour {

	[SerializeField] GameObject waterDrop;
	[SerializeField] GameObject map;
	private List<GameObject> waterList;

	// Use this for initialization
	void Start () {
		waterList= new List<GameObject>();
		GameObject first = Instantiate (waterDrop, new Vector3 (22, 12, 0), Quaternion.Euler (270,0,0));
		first.transform.parent = map.transform;
		waterList.Add (first);

		first = Instantiate (waterDrop, new Vector3 (23, 12, 0), Quaternion.Euler (270,0,0));
		first.transform.parent = map.transform;
		waterList.Add (first);

		first = Instantiate (waterDrop, new Vector3 (24,12, 0), Quaternion.Euler (270,0,0));
		first.transform.parent = map.transform;
		waterList.Add (first);
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Vertical") * Time.deltaTime * 20f;
		Debug.Log (waterList.Count);
		foreach (GameObject waterdrop in waterList) {
			waterdrop.transform.Translate (0, x, 0);
		}
	}

	void initialize(){
	}
}
