using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Text_Level : MonoBehaviour
{
    public Text text;


    private int Level = 1;
    private string Boss_Name = "Inicial Boss";
    private int Boss_Level = 5;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Level      = Game_Manager.instance.Show_Level();
        Boss_Level = Game_Manager.instance.Show_Boss_Level();

        if ((Level % Boss_Level) == 0 && Level != 0)
        {
            Boss_Name = Game_Manager.instance.Show_Enemy_Boss_Name();
            text.text = Boss_Name + ("(Boss)") + "Level : " + Level;
        }
        else
        {
            text.text = "Level : " + Level;
        }
    }
}
