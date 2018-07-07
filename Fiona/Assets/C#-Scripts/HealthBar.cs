﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	private Slider healthbar;
	private GameObject handle;
	private Color32 color1,color2;
	private GameObject player;

	void Start () {
		// Get Player
		player =GameObject.FindGameObjectWithTag("Player");
		//Set Healthbar stats
		healthbar = this.GetComponent<Slider> ();
		healthbar.maxValue = GameSingelton.PlayerMaxHealth;

		handle = healthbar.transform.GetChild (2).gameObject.transform.GetChild(0).gameObject;
		GameObject tmpObj = healthbar.transform.GetChild (0).gameObject;
		Image tmpImg = tmpObj.GetComponent<Image> ();
		color2 = tmpImg.color;
	}

	// Update is called once per frame
	void Update () {
        float currentHP = GameSingelton.Instance.PlayerHealth;

        if ( currentHP> 0) {
			healthbar.value = currentHP;
		} else {
			Image image = handle.GetComponent<Image> ();
			image.color = color2;
		}
	}
}
