using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingelton : MonoBehaviour {

    private static GameSingelton instance = null;
    private float DRAIN_RATE = 0.1f;
    private enum sceneAllowed { Load, MainMenu,Game }

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
        print("bla");
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        //time++;
        PlayerPoint = 0;
        PlayerHealth = 10;
        StartCoroutine(LoadYourSceneAsync());
    }
    void Update()
    {
        //get Player 
        //PlayerPoint++;
        if (start)
        { DrainHealth(); }
        if (PlayerHealth <= 0)
        {
            start = false;

            //stop "update" and show menu for restart and going to Menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PlayerHealth = 10;
                UnityEngine.SceneManagement.SceneManager.LoadScene((int)sceneAllowed.MainMenu);
            }
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
            {
                start = true;
                PlayerHealth = 10;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Paul");
            }
        }
        Debug.Log(/**"Points "+PlayerPoint+**/"Health  "+PlayerHealth);
    }
    public void DrainHealth()
    {
        PlayerHealth -= DRAIN_RATE;
    }
    public void RestoreHealth(float h) { PlayerHealth += h; }
    IEnumerator LoadYourSceneAsync()
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int)sceneAllowed.MainMenu);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
	
}
