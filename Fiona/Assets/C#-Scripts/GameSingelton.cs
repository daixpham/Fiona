using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class GameSingelton : MonoBehaviour {

    private static GameSingelton instance = null;
    private float DRAIN_RATE = 0.1f;
    private enum sceneAllowed { Load=0, MainMenu=1,Game =2}

    public uint time { get; private set; }
    public uint TotalTimePlayed { get; private set; }
    public float distance { get; set; }
    public float TotalDistance { get; private set; }
    public int PlayerPoint { get; private set; }
    public float PlayerHealth { get; private set; }

    public bool start;
    // Use this for initializationv
    public static GameSingelton Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton has't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        resetVariables();
        StartCoroutine(LoadYourSceneAsync(1));
    }

    private void FixedUpdate()
    {
        time++;
    }

    void Update()
    {
        //get Player 
        //PlayerPoint++;
        if (start)
        { DrainHealth(); }
        if (!start && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name =="Paul" )
        {
            start = false;

            //stop "update" and show menu for restart and going to Menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                resetVariables();
                UnityEngine.SceneManagement.SceneManager.LoadScene((int)sceneAllowed.MainMenu);
            }
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
            {
                resetVariables();
                start = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene((int)sceneAllowed.Game);
            }
        }
        Debug.Log(/**"Points "+PlayerPoint+**/"Health  "+PlayerHealth);
    }

    private void resetVariables()
    {
        time = 0;
        PlayerHealth = 3;
        PlayerPoint = 0;
        distance = 0;
    }

    public void Distance(uint dis)
    {
        distance+= dis;
    }

    public void DrainHealth()
    {
        PlayerHealth -= DRAIN_RATE;
        if (PlayerHealth <= 0) start = false;
    }
    public void RestoreHealth(float h) { PlayerHealth += h; }

    IEnumerator LoadYourSceneAsync(int i)
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(i);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
	
}
