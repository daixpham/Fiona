// To use this example, attach this script to an empty GameObject.
// Create two buttons (Create>UI>Button). Next, click your
// empty GameObject in the Hierarchy and click and drag each of your
// Buttons from the Hierarchy to the Your First Button and "Your Second Button"
// fields in the Inspector.
// Click each Button in Play Mode to output the message to the console.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

	[SerializeField] GameObject mainMenu;
	[SerializeField] GameObject settingsMenu;
	[SerializeField] GameObject creditsMenu;
	[SerializeField] GameObject tutorialMenu;
	[SerializeField] Text difficultyText;
	[SerializeField] Slider slider;
    //Make sure to attach these Buttons in the Inspector
    public Button m_Start, m_Exit, m_Credits;
    public bool CreditsB { get; private set; }
    void Start()
    {
        Button btn1 = m_Start.GetComponent<Button>();
        Button btn2 = m_Exit.GetComponent<Button>();
        Button btn3 = m_Credits.GetComponent<Button>();
        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        btn1.onClick.AddListener(TaskOnClick);
        //   btn2.onClick.AddListener(delegate { TaskWithParameters("Hello"); });
        btn2.onClick.AddListener(TaskOnClick);
        btn3.onClick.AddListener(TaskOnClick);

		mainMenu.SetActive (true);
		settingsMenu.SetActive (false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
  //          print("Return");
        }
    }
    void TaskOnClick()
    {
        //Output this to console when the Button is clicked
        if (EventSystem.current.currentSelectedGameObject.name.ToString().Equals("Exit"))
        {
//            print("Quit");
            Application.Quit();
        }
        if (EventSystem.current.currentSelectedGameObject.name.ToString().Equals("Start"))
        {
//            print("Start");
            SceneManager.LoadScene(2);
            GameSingelton.start = true;
        }


        Debug.Log("You have clicked the button!");
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button is clicked
        Debug.Log(message);
    }


	public void openSettings(){
		mainMenu.SetActive (false);
		settingsMenu.SetActive (true);
	}

	public void openCredits(){
		mainMenu.SetActive (false);
		creditsMenu.SetActive (true);
	}

	public void openTutorial(){
		mainMenu.SetActive (false);
		tutorialMenu.SetActive (true);
	}

	public void startGame(){
		print("Start");
		SceneManager.LoadScene(2);
		GameSingelton.start = true;
	}

	public void openMainMenu(){
		mainMenu.SetActive (true);
		settingsMenu.SetActive (false);
		creditsMenu.SetActive (false);
	}

	public void closeGame(){
		print("Quit");
		Application.Quit();
	}

	public void difficultyChange(){
		float f = slider.value;
		if (f == 0) {
			difficultyText.text = "Schwierigkeitsgrad: Einfach";
			GameSingelton.PlayerMaxHealth = 200;
			GameSingelton.scoreMult = 1;
		}
		else if (f == 1) {
			difficultyText.text = "Schwierigkeitsgrad: Normal";
			GameSingelton.PlayerMaxHealth = 100;
			GameSingelton.scoreMult = 2;
		}

		else{
			difficultyText.text = "Schwierigkeitsgrad: Schwer";
			GameSingelton.PlayerMaxHealth = 50;
			GameSingelton.scoreMult = 3;
		}

		Debug.Log (difficultyText);
	}
}
