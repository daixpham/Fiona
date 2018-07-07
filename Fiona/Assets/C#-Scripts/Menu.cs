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
public class Menu : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button m_Start, m_Exit, m_Credits;
    public Image imgCredits;
    public bool CreditsB { get; private set; }
    private Vector3 imgPos;
    void Start()
    {
        Button btn1 = m_Start.GetComponent<Button>();
        Button btn2 = m_Exit.GetComponent<Button>();
        Button btn3 = m_Credits.GetComponent<Button>();
        Image img = imgCredits.GetComponent<Image>();
        imgPos = imgCredits.transform.position;
        changeAlpha(0);
        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        btn1.onClick.AddListener(TaskOnClick);
        //   btn2.onClick.AddListener(delegate { TaskWithParameters("Hello"); });
        btn2.onClick.AddListener(TaskOnClick);
        btn3.onClick.AddListener(TaskOnClick);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            changeAlpha(0);
            print("Return");
        }
    }
    void TaskOnClick()
    {
        //Output this to console when the Button is clicked
        if (EventSystem.current.currentSelectedGameObject.name.ToString().Equals("Exit"))
        {
            print("Quit");
            Application.Quit();
        }
        if (EventSystem.current.currentSelectedGameObject.name.ToString().Equals("Credits"))
        {
            print("Credits");
            //load Credits
            changeAlpha(1);
        }
        if (EventSystem.current.currentSelectedGameObject.name.ToString().Equals("Start"))
        {
            print("Start");
            SceneManager.LoadScene("Paul");
        }
        Debug.Log("You have clicked the button!");
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button is clicked
        Debug.Log(message);
    }
    void changeAlpha(int i)
    {
        Color c = imgCredits.color;
        c.a = i;
        imgCredits.color = c;
        if (i == 1)
        {
            imgCredits.transform.position = imgPos;
            CreditsB = true;
        }
        else
        {
            CreditsB = false;
            imgCredits.transform.position = new Vector3(-100,-100,0);
        }

    }
}