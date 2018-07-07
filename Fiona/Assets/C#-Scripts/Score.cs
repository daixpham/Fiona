using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Score : MonoBehaviour
{


    public Text scoreText;
    private int score;
    // Use this for initialization
    public Button m_Menu, m_Restart;

    void Start()
    {
        Button menu = m_Menu.GetComponent<Button>();
        Button restart = m_Restart.GetComponent<Button>();
        score = 0;
        scoreUpdate();
        menu.onClick.AddListener(TaskOnClick);
        restart.onClick.AddListener(TaskOnClick);
        menu.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameSingelton.start)
        {
            GameSingelton.Instance.UpdateScore();
            score = GameSingelton.Instance.PlayerPoint;

            scoreUpdate();
        }
        else
        {
            m_Menu.gameObject.SetActive(true);
            m_Restart.gameObject.SetActive(true);
        }

        scoreUpdate();

    }

    void scoreUpdate()
    {
        scoreText.text = "Score: " + score;
    }

    void TaskOnClick()
    {
        if (EventSystem.current.currentSelectedGameObject.name.ToString().Equals("Restart")||Input.GetKeyDown(KeyCode.Return))
        {
            GameSingelton.ButtonRestart = true;
        }
        if (EventSystem.current.currentSelectedGameObject.name.ToString().Equals("Menu") || Input.GetKeyDown(KeyCode.Escape))
        {
            GameSingelton.ButtonMenu = true;
        }
    }

}