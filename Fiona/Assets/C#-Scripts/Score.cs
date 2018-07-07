using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {


    public Text scoreText;
    private int score;

    // Use this for initialization
    void Start()
    {
        score = 0;
        scoreUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        GameSingelton.Instance.UpdateScore();
        score = GameSingelton.Instance.PlayerPoint;

        scoreUpdate();
    }

    void scoreUpdate()
    {
        scoreText.text = "Score: " + score;
    }
}
