﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Score : MonoBehaviour
{


    public Text scoreText;
    public Text endScore;
    private int score;
    private bool first;
    // Use this for initialization
    public Button m_Menu, m_Restart;
    public Image img;
    bool mRestart;
    bool mMenu;

    void Start()
    {
        Button menu = m_Menu.GetComponent<Button>();
        Button restart = m_Restart.GetComponent<Button>();
        score = 0;
        scoreUpdate();
        menu.onClick.AddListener(TaskOnClick);
        restart.onClick.AddListener(TaskOnClick);

        mMenu = false;
        mRestart = false;

        endScore.gameObject.SetActive(false);
        img.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
 
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSingelton.start)
        {
            GameSingelton.Instance.UpdateScore();
            scoreUpdate();
        }
        else
        {
            m_Menu.gameObject.SetActive(true);

            m_Restart.gameObject.SetActive(true);
            endScore.gameObject.SetActive(true);
            img.gameObject.SetActive(true);

            scoreUpdate();
            if(Input.GetKeyDown(KeyCode.Return))
                GameSingelton.ButtonRestart = true;
            endScore.text = "Your Score was: " + score;
        }
        
        scoreUpdate();

    }

    void scoreUpdate()
    {
        score = GameSingelton.Instance.PlayerPoint;
        scoreText.text = "Score: " + score;
    }

    void TaskOnClick()
    {
        if (EventSystem.current.currentSelectedGameObject.name.ToString().Equals("Restart") || Input.GetKeyDown(KeyCode.Return))
        {
//            print("AAAAAAAAAAAAAAAAAAAAAAAAAAA");
            GameSingelton.ButtonRestart = true;
        }
        if (EventSystem.current.currentSelectedGameObject.name.ToString().Equals("Menu") || Input.GetKeyDown(KeyCode.Escape))
        {
            GameSingelton.ButtonMenu = true;
        }
    }

}