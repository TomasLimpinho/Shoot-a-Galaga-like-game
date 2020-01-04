using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    //[SerializeField] private GameObject pausePanel;
    public static Pause instance = null;

    public Button yourButton;

    public Button HouseButton;

    public Button btn;

    public Sprite Go;
    public Sprite Stop;

    public Text Pause_Text_Score_Highest;

    public Text Pause_Text_Score_Now;

    public Text Pause_Text_Score_Highest2;

    public Text Pause_Text_Score_Now2;

    public RawImage Pause_Mini_Screen_Color_0;

    public RawImage Pause_Mini_Screen_Color_1;

    public RawImage Pause_Mini_Screen_Color_2;

    public RawImage Pause_Mini_Screen_Color_3;

    public RawImage Pause_Back_Screen_Color;

    public float Anum = -245f;

    public float Anum_x = 82.122f ;

    public void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        Button btn = this.yourButton.GetComponent<Button>();

        btn.image.sprite = Go;

        btn.transform.gameObject.SetActive(false);

        btn.onClick.AddListener(TaskOnClick);

        Pause_Text_Score_Highest.CrossFadeAlpha(-1.0f, 0.05f, true);
        Pause_Text_Score_Now.CrossFadeAlpha(-1.0f, 0.05f, true);
        Pause_Mini_Screen_Color_0.CrossFadeAlpha(-1.0f, 0.05f, true);
        Pause_Mini_Screen_Color_1.CrossFadeAlpha(-1.0f, 0.05f, true);

        Pause_Text_Score_Highest2.CrossFadeAlpha(-1.0f, 0.05f, true);
        Pause_Text_Score_Now2.CrossFadeAlpha(-1.0f, 0.05f, true);
        Pause_Mini_Screen_Color_2.CrossFadeAlpha(-1.0f, 0.05f, true);
        Pause_Mini_Screen_Color_3.CrossFadeAlpha(-1.0f, 0.05f, true);

        Pause_Back_Screen_Color.CrossFadeAlpha(-1.0f, 0.05f, true);

        HouseButton.transform.gameObject.SetActive(false);
    }


    public void TaskOnClick()
    {


        if(yourButton.image.sprite == Stop)
        {
            PauseGame();
            Game_Manager.instance.startingg(1);
        }
        else
        {
            StartGame();
            Game_Manager.instance.startingg(0);
        }


    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        yourButton.image.sprite = Go;

        Pause_Text_Score_Highest.CrossFadeAlpha(100.0f, 0.05f, true);
        Pause_Text_Score_Now.CrossFadeAlpha(100.0f, 0.05f, true);
        Pause_Mini_Screen_Color_0.CrossFadeAlpha(50.0f, 0.05f, true);
        Pause_Mini_Screen_Color_1.CrossFadeAlpha(50.0f, 0.05f, true);


        Pause_Text_Score_Highest2.CrossFadeAlpha(100.0f, 0.05f, true);
        Pause_Text_Score_Now2.CrossFadeAlpha(100.0f, 0.05f, true);
        Pause_Mini_Screen_Color_2.CrossFadeAlpha(50.0f, 0.05f, true);
        Pause_Mini_Screen_Color_3.CrossFadeAlpha(50.0f, 0.05f, true);

        Pause_Back_Screen_Color.CrossFadeAlpha(5.0f, 0.05f, true); //ultimo

        HouseButton.transform.gameObject.SetActive(true);
        HouseButton.GetComponent<RectTransform>().anchoredPosition =  new Vector2(Anum_x, Anum);
 
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        yourButton.image.sprite = Stop;

        Pause_Text_Score_Highest.CrossFadeAlpha(0.0f, 0.05f, true);
        Pause_Text_Score_Now.CrossFadeAlpha(0.0f, 0.05f, true);
        Pause_Mini_Screen_Color_0.CrossFadeAlpha(0.0f, 0.05f, true);
        Pause_Mini_Screen_Color_1.CrossFadeAlpha(0.0f, 0.05f, true);

        Pause_Text_Score_Highest2.CrossFadeAlpha(0.0f, 0.05f, true);
        Pause_Text_Score_Now2.CrossFadeAlpha(0.0f, 0.05f, true);
        Pause_Mini_Screen_Color_2.CrossFadeAlpha(0.0f, 0.05f, true);
        Pause_Mini_Screen_Color_3.CrossFadeAlpha(0.0f, 0.05f, true);

        Pause_Back_Screen_Color.CrossFadeAlpha(-1.0f, 0.05f, true);

        HouseButton.transform.gameObject.SetActive(false);
    }

    public void going_home()
    {
        Pause_Text_Score_Highest.CrossFadeAlpha(-1.0f, 0.05f, true);
        Pause_Text_Score_Now.CrossFadeAlpha(-1.0f, 0.05f, true);
        Pause_Mini_Screen_Color_0.CrossFadeAlpha(-1.0f, 0.05f, true);
        Pause_Mini_Screen_Color_1.CrossFadeAlpha(-1.0f, 0.05f, true);

        Pause_Text_Score_Highest2.CrossFadeAlpha(-1.0f, 0.05f, true);
        Pause_Text_Score_Now2.CrossFadeAlpha(-1.0f, 0.05f, true);
        Pause_Mini_Screen_Color_2.CrossFadeAlpha(-1.0f, 0.05f, true);
        Pause_Mini_Screen_Color_3.CrossFadeAlpha(-1.0f, 0.05f, true);

        Pause_Back_Screen_Color.CrossFadeAlpha(-1.0f, 0.05f, true);

        HouseButton.transform.gameObject.SetActive(false);
    }
}
