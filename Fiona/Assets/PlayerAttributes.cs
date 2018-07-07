using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour {
	[SerializeField] private float maxHP= 100;
	[SerializeField] private float currentHP= 100;
	[SerializeField] private float decay = 5;
	[SerializeField] private bool isAlive = true;
	private Vector3 pos;
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive) {
			currentHP -= Time.deltaTime * decay;

		}
	}

	public bool getStatus(){
		return isAlive;
	}

	public float getCurrentHP(){
		return currentHP;
	}

	public float getMaxHP(){
		return maxHP;
	}
}
