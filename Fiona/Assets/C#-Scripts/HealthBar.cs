using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public float healthPoints = 100;
	public float reductionFactor = 5;
	private Slider healthbar;
	private GameObject handle;
	private Color32 color1,color2;


	void Start () {
		
		healthbar = this.GetComponent<Slider> ();
		healthbar.maxValue = healthPoints;
		handle = healthbar.transform.GetChild (2).gameObject.transform.GetChild(0).gameObject;
		GameObject tmpObj = healthbar.transform.GetChild (0).gameObject;
		Debug.Log (tmpObj);
		Image tmpImg = tmpObj.GetComponent<Image> ();
		color2 = tmpImg.color;
	}

	// Update is called once per frame
	void Update () {
		if (healthPoints > 0) {
			healthPoints -= Time.deltaTime * reductionFactor;
			healthbar.value = healthPoints;
		} else {
			Image image = handle.GetComponent<Image> ();
			image.color = color2;
		}
	}
}
