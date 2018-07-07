using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class TestAnimationScript : MonoBehaviour {

    private bool _running;
    private bool _jumping;
    private bool _landing;
    private bool _dead;

    public Animator controller;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _running = !_running;
            controller.SetBool("IsRunning", _running);
        }
	}
}
