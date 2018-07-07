using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {


    public Text scoreText;
    private int score;
    public Text MenuEscapeScore;
    // Use this for initialization
    void Start()
    {
        score = 0;
        scoreUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        print(GameSingelton.start);
        if (GameSingelton.start)
        {
            GameSingelton.Instance.UpdateScore();
            score = GameSingelton.Instance.PlayerPoint;
 
            scoreUpdate();
        }

        scoreUpdate();
        onDeath();
    }

    void scoreUpdate()
    {
        scoreText.text = "Score: " + score;
    }

    void onDeath()
    {
        MenuEscapeScore.text = "Restart Press Any Key \n Main Menu Escape \n your score was :" + score;
    }
}
