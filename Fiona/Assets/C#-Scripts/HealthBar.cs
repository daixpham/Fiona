using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public float healthPoints = 100;
	public float reductionFactor = 5;
	private Slider healthbar;
	private GameObject handle;


	void Start () {
		healthbar = this.GetComponent<Slider> ();
		healthbar.maxValue = healthPoints;
		handle = healthbar.transform.GetChild (2).gameObject.transform.GetChild(0).gameObject;
	}

	// Update is called once per frame
	void Update () {
		if (healthPoints > 0) {
			healthPoints -= Time.deltaTime * reductionFactor;
			healthbar.value = healthPoints;
		} else {
			Image image = handle.GetComponent<Image> ();
			Debug.Log (image.color);
		}
	}
}
