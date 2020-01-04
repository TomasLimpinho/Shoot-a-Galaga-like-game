using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achivments : MonoBehaviour
{
    public static Achivments instance = null;

    public string[] Achivement_Name;
    public int[] Shosed_Request;
    public string Achivement_Acompliched;
    public int[] Skin_Unblocked;
    public ulong Skins;
    public int Skins_Max;
    // Start is called before the first frame update
    
    public void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        AnalizarAchivements();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnalizarAchivements()
    {
        ulong.TryParse(Savings.instance.Show_Skins(), out Skins);
    
        for (int i = 0; i < Achivement_Name.Length; i++)
        {
            if (Achivement_Name[i] != null)
            {
                if (Achivement_Name[i].Contains("Score_Reached_") == true)
                {
                    Achivemente_Per_Score(i);
                }
                else if (Achivement_Name[i].Contains("Level_Reached_") == true)
                {
                    Achivemente_Per_Level_Rechead(i);
                }
            }
        }
        Savings.instance.Change_Achivments(Achivement_Acompliched);

        for (int i = 0; i < Achivement_Name.Length; i++)
        {
            Achivemente_Skins(i);
        }
    }  
    public int Achivemente_Per_Level_Rechead(int i)
    {
        if(Savings.instance.Show_Score_Highest() >= Shosed_Request[i]) {

            char[] paisArray = Achivement_Acompliched.ToCharArray();

            // Substitui o caracter via índice
            paisArray[i] = '1';

            // Junta novamente todos os caracteres em uma string
            Achivement_Acompliched = new string(paisArray);
        }
        return 1;
    }
    public int Achivemente_Per_Score(int i)
    { 
        if (Savings.instance.Show_Score_Highest2() >= Shosed_Request[i])
        {
            // Transforma a string em um array de char (char[])
            char[] paisArray = Achivement_Acompliched.ToCharArray();

            // Substitui o caracter via índice
            paisArray[i] = '1';

            // Junta novamente todos os caracteres em uma string
            Achivement_Acompliched = new string(paisArray);
        }
        return 1;
    }
    public void Achivemente_Skins(int i)
    {
        
        ulong num = 1;
        num = 1;
        if(Achivement_Acompliched[i] == '1' && Skin_Unblocked[i] != -1)
        {
          
            // Substitui o caracter via índice
            if (Savings.instance.Show_Skins()[Skin_Unblocked[i]] == '0')
            {
                for (int i2 = 0; i2 < ((Skins_Max - Skin_Unblocked[i])); i2++)
                {

                    num = num * 10;
                }
                Skins += num;
            }
            Savings.instance.Change_Skins2(Skins);
        }
       
   }
}
