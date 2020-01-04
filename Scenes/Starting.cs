using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Starting : MonoBehaviour
{
    //[SerializeField] private GameObject pausePanel;

    public static Starting instance = null;

    public GameObject Barra_Vida;

    public Button yourButton;

    public Button Start_Button_Start;

    public Button Start_Button_Config;

    public Button Start_Button_Skins;

    public Button Start_Button_HighScore;

    public Button Skins_Button_Left;
     
    public Button Skins_Button_Right;

    public RawImage Start_Back_Screen_Color;

    public RawImage Pause_Back_Screen_Color;

    //public RawImage Color_Life;
    public RawImage Color_Level;

    public Button Pause_Button_Pause;

    public Sprite Go;
    public Sprite Stop;

    public Text Score_Highest;
    public Text Score_Now;
    
    public Text text1;
    //public Text text2;

    public Text CopyRights;
    private int onSkins = 0;
    //    public Vetor2 OriginalPoint = (0f, 0f, 0f);
    public float Anum = 928.31f;

    public RawImage Showing_Skins;

    private int activate = 0;


    public float skins_posx = 46;
    public float skins_posy = 114;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 0;

        yourButton.onClick.AddListener(TaskOnClick);

        Start_Button_Start.onClick.AddListener(TaskOnClick2);

        Start_Button_Skins.onClick.AddListener(Activate_Skins_Screen);


        Pause_Back_Screen_Color.CrossFadeAlpha(-1.0f, 0.05f, true);
        Start_Back_Screen_Color.CrossFadeAlpha(2.0f, 0.05f, true);

        Color_Level.CrossFadeAlpha(-1.0f, 0.05f, true);

        text1.CrossFadeAlpha(0.0f, 0.05f, true);

        Score_Highest.CrossFadeAlpha(0.0f, 0.05f, true);
        Score_Now.CrossFadeAlpha(0.0f, 0.05f, true);
        CopyRights.CrossFadeAlpha(1.0f, 0.05f, true);

       
        Skins_Button_Left.transform.gameObject.SetActive(false);
        Skins_Button_Right.transform.gameObject.SetActive(false);
    }

    public void TaskOnClick()
    {

        PauseGame();
        Game_Manager.instance.House_Mode_Change(0);
        Pause_Button_Pause.image.sprite = Go;
        Game_Manager.instance.startingg(1);
        Time.timeScale = 0;
    }

    public void TaskOnClick2()
    {

        StartGame();
        Game_Manager.instance.House_Mode_Change(1);
        Pause_Button_Pause.image.sprite =  Stop;
        Game_Manager.instance.startingg(0);
        Time.timeScale = 1;
        Pause.instance.StartGame();
    }

    public void Activate_Skins_Screen()
    {
        SkinsScreen(); 
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        //BUTTONS

        Pause.instance.going_home();

        Start_Button_Start.transform.gameObject.SetActive(true);
        Start_Button_Config.transform.gameObject.SetActive(true);
        Start_Button_Skins.transform.gameObject.SetActive(true);
        Start_Button_HighScore.transform.gameObject.SetActive(true);
        if (onSkins == 1)
        {
            yourButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(600f, -550f);
            onSkins = 0;
        }
        yourButton.transform.gameObject.SetActive(false);
        Pause_Button_Pause.transform.gameObject.SetActive(false);
        
        //BACKGROUND COLOR
        Pause_Back_Screen_Color.CrossFadeAlpha(-10.0f, 0.05f, true);
        Start_Back_Screen_Color.CrossFadeAlpha(10.0f, 0.05f, true);
        text1.CrossFadeAlpha(0.0f, 0.05f, true);



        Color_Level.CrossFadeAlpha(-1.0f, 0.05f, true);
        Score_Highest.CrossFadeAlpha(0.0f, 0.05f, true);
        Score_Now.CrossFadeAlpha(0.0f, 0.05f, true);
        CopyRights.CrossFadeAlpha(1.0f, 0.05f, true);


        Game_Manager.instance.returning_Home();



        Showing_Skins.transform.gameObject.SetActive(false);


        Skins_Button_Left.transform.gameObject.SetActive(false);
        Skins_Button_Right.transform.gameObject.SetActive(false);

        Achivments.instance.AnalizarAchivements();

        if (Show_Activate() == 1) { Activating(0); Skins_Show.instance.Desactivated(); }

    }

    public void SkinsScreen()
    {
        //BUTTONS
        Start_Button_Start.transform.gameObject.SetActive(false);
        Start_Button_Config.transform.gameObject.SetActive(false);
        Start_Button_Skins.transform.gameObject.SetActive(false);
        Start_Button_HighScore.transform.gameObject.SetActive(false);
        Skins_Button_Left.transform.gameObject.SetActive(true);
        Skins_Button_Right.transform.gameObject.SetActive(true);

        yourButton.transform.gameObject.SetActive(true);
        yourButton.GetComponent<RectTransform>().anchoredPosition =  new Vector2(42.122f, Anum);
 
        //BACKGROUND COLOR
        text1.CrossFadeAlpha(0.0f, 0.05f, true);

        CopyRights.CrossFadeAlpha(-1.0f, 0.05f, true);

        Activating(1);
        Skins_Show.instance.Activated();

      
        Showing_Skins.transform.gameObject.SetActive(true);


    }

    private void StartGame()
    {


        Time.timeScale = 1;

        //BUTTONS
        Start_Button_Start.transform.gameObject.SetActive(false);
        Start_Button_Config.transform.gameObject.SetActive(false);
        Start_Button_Skins.transform.gameObject.SetActive(false);
        Start_Button_HighScore.transform.gameObject.SetActive(false);
        yourButton.transform.gameObject.SetActive(false);
        Pause_Button_Pause.transform.gameObject.SetActive(true);
        text1.CrossFadeAlpha(100.0f, 0.05f, true);

        Color_Level.CrossFadeAlpha(2.0f, 0.05f, true);
        CopyRights.CrossFadeAlpha(0.0f, 0.05f, true);

        //BACKGROUND COLOR
        Start_Back_Screen_Color.CrossFadeAlpha(-1.0f, 0.05f, true); //ultimo


    }
    
    public void Activating(int i)
    {
        activate = i;
    }

    public int Show_Activate()
    {
        return activate;
    }
}
