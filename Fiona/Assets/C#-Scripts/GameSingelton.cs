using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class GameSingelton : MonoBehaviour {

    [SerializeField]private static GameSingelton instance = null;

    private enum sceneAllowed { Load=0, MainMenu=1,Game =2}

    public uint time { get; private set; }
    public uint TotalTimePlayed { get; private set; }
    public float distance { get; set; }
    public float TotalDistance { get; private set; }
    public int PlayerPoint { get; private set; }
    private static bool blub = true;
	public static float PlayerHealth { get; private set; }
    public  static float DRAIN_RATE { get; set; }
    public static float PlayerMaxHealth { get; set; }
	public static int scoreMult { get; set; }

    public static bool start;
    public static bool ButtonMenu ;
    public static bool ButtonRestart ;
    public static bool Tutorial = true;
    private static bool first;
    public static float sandstormSpeed { get; set; }
    public static float DrainSpeedSandstrom { get; private set; }// this is for the Sandstorm
    public static float spawnSpeed;
    public static float difficulty = 1;
    public static float SPEED = 0.3f;
   
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
        DRAIN_RATE = 0.1f;
        DrainSpeedSandstrom = 0.2f;
        sandstormSpeed = 0.05f;
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
        if (blub&&start)
        {
            Debug.Log(difficulty);
            changeDifficulty(difficulty);
            resetVariables();
            blub = false;
        }
        if (start)
        {
            DrainHealth();
            ButtonMenu = false;
            ButtonRestart= false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                resetVariables();
                start = false;
                blub = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene((int)sceneAllowed.MainMenu);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayerHealth = 0;
            }
        }
        if (!start)
        {
            //stop "update" and show menu for restart and going to Menu
            if (ButtonMenu)
            {
                resetVariables();
                start = false;
                blub = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene((int)sceneAllowed.MainMenu);
            }
            if (ButtonRestart)
            {
                resetVariables();
                start = true;
                blub = true;
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

    public static void changeDifficulty(float f)
    {
        if (f == 0)
        {
            WaterDrop.WaterRegen = 15;
            PlayerMaxHealth = 200;
            scoreMult = 1;
            DRAIN_RATE = 0.1f;
            sandstormSpeed = 0.05f;
            spawnSpeed = 2.5f;
            SPEED = 0.3f;
        }
        else if (f == 1)
        {
            WaterDrop.WaterRegen = 12;
            PlayerMaxHealth = 100;
            scoreMult = 2;
            DRAIN_RATE = 0.1f;
            sandstormSpeed = 0.2f;
            spawnSpeed = 3f;
            SPEED = 0.3f;
        }

        else
        {
            WaterDrop.WaterRegen = 11;
            PlayerMaxHealth = 50;
            scoreMult = 3;
            DRAIN_RATE = 0.2f;
            sandstormSpeed = 2f;
            spawnSpeed = 1f;
            SPEED = 0.3f;
        }
    }


}
