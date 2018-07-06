using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBackgroundImage : MonoBehaviour {
	[SerializeField] private GameObject bg01;
	[SerializeField] private GameObject bg02;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject playerCam;
	[SerializeField] private GameObject background;
	private float fieldOfView;
	private float offset;
	// Use this for initialization
	void Start () {
		Camera tmp = playerCam.GetComponent<Camera> ();
		fieldOfView = tmp.fieldOfView;
		offset = bg02.transform.position.x - bg01.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		bg01.transform.Translate (-Time.deltaTime*5,0, 0);
		bg02.transform.Translate (-Time.deltaTime*5,0, 0);

		if (bg01.transform.position.x < player.transform.position.x-fieldOfView) {
			GameObject tmp = bg01;
			Destroy(tmp);
			bg01 = transform.GetChild (1).gameObject;
			bg02 = Instantiate (background, new Vector3 (bg01.transform.position.x+offset, 0, 0), Quaternion.identity);
			bg02.transform.parent = transform;

		}
	}
}
