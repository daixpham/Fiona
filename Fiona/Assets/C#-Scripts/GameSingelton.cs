using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class GameSingelton : MonoBehaviour {

    [SerializeField]private static GameSingelton instance = null;
    private float DRAIN_RATE = 0.1f;
    private enum sceneAllowed { Load=0, MainMenu=1,Game =2}

    public uint time { get; private set; }
    public uint TotalTimePlayed { get; private set; }
    public float distance { get; set; }
    public float TotalDistance { get; private set; }
    public int PlayerPoint { get; private set; }
	public static float PlayerHealth { get; private set; }
	public static float PlayerMaxHealth { get; set; }
	public static int scoreMult { get; set; }

    public static bool start;
    public static bool ButtonMenu ;
    public static bool ButtonRestart ;
    public static bool Tutorial = true;
    private static bool first;
    public const float SPEED = 0.3f;
    public  Vector3 move { get; set; }
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
        if (first)
        {
            Destroy(this.gameObject);
        }
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        first = true;
        DontDestroyOnLoad(this.gameObject);
        Application.targetFrameRate=60;
    }
    void Start()
    {

        move = new Vector3(SPEED,0,0);
        ButtonMenu = false;
        ButtonRestart = false;
        resetVariables();
        StartCoroutine(LoadYourSceneAsync((int)sceneAllowed.MainMenu));
		PlayerMaxHealth = 100;
		scoreMult = 2;
		PlayerHealth = PlayerMaxHealth;
    }

    public void UpdateScore()
    {
		PlayerPoint+=scoreMult;
    }
    private void FixedUpdate()
    {
        time++;
    }

    void Update()
    {
        //get Player 
        if (start)
        {
            DrainHealth();
            ButtonMenu = false;
            ButtonRestart= false;
        }
        if (!start)
        {
            //stop "update" and show menu for restart and going to Menu
            if (ButtonMenu)
            {
                resetVariables();
                start = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene((int)sceneAllowed.MainMenu);
            }
            if (ButtonRestart)
            {
                resetVariables();
                start = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene((int)sceneAllowed.Game);
            }
        }

    }

    private void resetVariables()
    {
        time = 0;
        PlayerHealth = PlayerMaxHealth;
        PlayerPoint = 0;
        distance = 0;
        ButtonMenu = false;
        ButtonRestart = false;
    }

    public void Distance(uint dis)
    {
        distance+= dis;
    }

    public void DrainHealth()
    {
        PlayerHealth -= DRAIN_RATE;
        if (PlayerHealth <= 0) { start = false; }
    }
    public void DrainHealth(float f)
    {
        PlayerHealth -= f;
        if (PlayerHealth <= 0) { start = false; }
    }

    public void RestoreHealth(float h) { 
		PlayerHealth += h; 
		if (PlayerHealth > PlayerMaxHealth) {
			PlayerHealth = PlayerMaxHealth;
		}

	}

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
