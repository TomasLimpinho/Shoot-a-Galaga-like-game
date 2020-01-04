using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins_Show : MonoBehaviour
{
    public static Skins_Show instance = null;
    //Set this in the Inspector
    public Texture item_0;
    public Texture item_1;
    public Texture item_2;
    public Texture item_3;
    public Texture item_4;
    public Texture item_5;
    public Texture item_6;
    public Texture item_7;
    public Texture item_8;
    public Texture item_9;
    public Texture item_10;
    public Texture item_11;
    public Texture item_12;
    public Texture item_13;
    public Texture item_14;
    public Texture item_15;

    public Transform item_atual;

    public RawImage Lock_Image;

    public int item_num;
    Dictionary<int, Texture> Inventory = new Dictionary<int, Texture>();
    public int i;

    public RawImage sR;

    public Button Button_Right;

    public Button Button_Left;

    public string skinner;

    public int Skin_Max = 15;

    public float posx = 46f;
    public float posy = 114f;
    public void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        sR = item_atual.GetComponent<RawImage>();

        Inventory.Add(0, item_0);
        Inventory.Add(1, item_1);
        Inventory.Add(2, item_2);
        Inventory.Add(3, item_3);
        Inventory.Add(4, item_4);
        Inventory.Add(5, item_5);
        Inventory.Add(6, item_6);
        Inventory.Add(7, item_7);
        Inventory.Add(8, item_8);
        Inventory.Add(9, item_9);
        Inventory.Add(10, item_10);
        Inventory.Add(11, item_11);
        Inventory.Add(12, item_12);
        Inventory.Add(13, item_13);
        Inventory.Add(14, item_14);
        Inventory.Add(15, item_15);

        item_num = Savings.instance.Show_Skin_Atual();

        sR.texture = Inventory[item_num];

        Button_Right.onClick.AddListener(TaskOnClick);
        Button_Left.onClick.AddListener(TaskOnClick2);



        sR.transform.gameObject.SetActive(false);
        Lock_Image.transform.gameObject.SetActive(false);
    }


    void Update()
    {

            int startw = Starting.instance.Show_Activate();
            if (startw == 1)
            {
                sR.texture = Inventory[item_num];
                skinner = Savings.instance.Show_Skins();
                if (skinner[item_num] == '0')
                {
                    Lock_Image.transform.gameObject.SetActive(true);
                    
                }
                else
                {
                Lock_Image.transform.gameObject.SetActive(false);
             

            }
        }
            else
            {
            Lock_Image.transform.gameObject.SetActive(false);

        }

    }

    public void TaskOnClick()
    {
        if (item_num >= 0 && item_num < Skin_Max)
        {
            item_num += 1;

        }
    }

    public void TaskOnClick2()
    {
        if (item_num > 0 && item_num <= Skin_Max)
        {
            item_num -= 1;

        }
    }

    public void Activated()
    {
        item_num = Savings.instance.Show_Skin_Atual();
    } 
    public void Desactivated()
    {
        if(skinner[item_num] == '1')
        { 
        Savings.instance.Change_Skin_Atual(item_num);
        }
    }
}
