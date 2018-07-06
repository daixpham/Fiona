using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBackgroundImage : MonoBehaviour {
	[SerializeField] private GameObject bg01;
	[SerializeField] private GameObject bg02;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject playerCam;
	private float fieldOfView;
	private float offset;
	// Use this for initialization
	void Start () {
		Camera tmp = playerCam.GetComponent<Camera> ();
		fieldOfView = tmp.fieldOfView;
		offset = bg02.transform.position.x - bg01.transform.position.x;
		Debug.Log (bg02.transform.position.x+" "+ bg01.transform.position.x +" Offset: "+offset);
//		bg01.transform.position.x = offset + bg02.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		bg01.transform.Translate (-Time.deltaTime*5,0, 0);
		bg02.transform.Translate (-Time.deltaTime*5,0, 0);
	}
}
