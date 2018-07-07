using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class TestAnimationScript : MonoBehaviour {

    private bool _running;
    public Animator controller;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _running = !_running;
            controller.SetBool("IsRunning", _running);
        }
	}
}
