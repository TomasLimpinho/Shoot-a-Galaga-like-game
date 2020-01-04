using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class Savings : MonoBehaviour
{
    public static Savings instance = null;

    public int Score_Highest = 0;
    public int Score_Highest2 = 0;

    public string Skins = "0000000000000010";

    public int Skin_Atual = 0;

    public int Skin_Max = 15;

    public string Achivement_Acompliched = "00000";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        //System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/Skins/Skins.txt", "0000000000000000");
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/HighScore2/HighScore2.txt", "" + 0);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/HighScore/HighScore.txt", "" + 0);


        if (!Directory.Exists(Application.persistentDataPath + "/Data/Shoot/HighScore"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/Shoot/HighScore");
        }
        if (!Directory.Exists(Application.persistentDataPath + "/Data/Shoot/HighScore2"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/Shoot/HighScore2");
        }
        if (!Directory.Exists(Application.persistentDataPath + "/Data/Shoot/Skins/Skins.txt"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/Shoot/Skins/Skins");
        }
        if (!Directory.Exists(Application.persistentDataPath + "/Data/Shoot/Skins/Skin_Atual"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/Shoot/Skins/Skin_Atual");
        }
        if (!Directory.Exists(Application.persistentDataPath + "/Data/Shoot/Achivements"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data/Shoot/Achivements");
        }

        if (!File.Exists(Application.persistentDataPath + "/Data/Shoot/HighScore/HighScore.txt"))
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/HighScore/HighScore.txt", "" + 0);
        }
        else { Score_Highest = Show_Score_Highest(); }

        if (!File.Exists(Application.persistentDataPath + "/Data/Shoot/HighScore2/HighScore2.txt"))
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/HighScore2/HighScore2.txt", "" + 0);
        }
        else { Score_Highest2 = Show_Score_Highest2(); }

        if (!File.Exists(Application.persistentDataPath + "/Data/Shoot/Skins/Skins.txt"))
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/Skins/Skins.txt", "" + Skins); //16 zeros one per skin
        }
        else { Skins  = Show_Skins(); }


        if (!File.Exists(Application.persistentDataPath + "/Data/Shoot/Skins/Skin_Atual.txt"))
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/Skins/Skin_Atual.txt", "" + 0);
        }
        else { Skin_Atual = Show_Skin_Atual(); }

        if (!File.Exists(Application.persistentDataPath + "/Data/Shoot/Achivements/Achivements.txt"))
        {
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/Achivements/Achivements.txt", "" + Achivement_Acompliched);  //4 zeros one per Achivement
        }
        else { Achivement_Acompliched = Show_Achivement_Acompliched(); }

    }


    public void Save(int Score_Now, int Score_Now2)
    {
        if (Score_Now > Score_Highest)
        {
            Score_Highest = Score_Now;
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/HighScore/HighScore.txt", "" + Score_Highest);
            
        }
        if (Score_Now2 > Score_Highest2)
        {
            Score_Highest2 = Score_Now2;
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/HighScore2/HighScore2.txt", "" + Score_Highest2);

        }
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/Skins/Skin_Atual.txt", "" + Skin_Atual);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/Skins/Skins.txt", "" + Skins);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/Achivements/Achivements.txt", "" + Achivement_Acompliched);

    }

    public int Show_Score_Highest()
    {
        return readTextFile(Application.persistentDataPath + "/Data/Shoot/HighScore/HighScore.txt");
    }

    public string Show_Achivement_Acompliched()
    {

        return File.ReadAllText(Application.persistentDataPath + "/Data/Shoot/Achivements/Achivements.txt");

    }

    public int Show_Score_Highest2()
    {
        return readTextFile(Application.persistentDataPath + "/Data/Shoot/HighScore2/HighScore2.txt");
    }

    public string Show_Skins()
    {
        return File.ReadAllText(Application.persistentDataPath + "/Data/Shoot/Skins/Skins.txt");
    }

    public int Show_Skin_Atual()
    {
        return readTextFile(Application.persistentDataPath + "/Data/Shoot/Skins/Skin_Atual.txt");
    }

    public void Change_Skin_Atual(int i)
    {
        if(i>=0 && i <= Skin_Max)
        { 
            Skin_Atual = i;
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Data/Shoot/Skins/Skin_Atual.txt", "" + Skin_Atual);
        }
    }

    public int readTextFile(string file_path)
    {
        string inp_ln = null;
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream)
        {
            inp_ln = inp_stm.ReadLine();
            // Do Something with the input. 
        }

        inp_stm.Close();

        return Convert.ToInt32(inp_ln);
    }
    public void Change_Achivments(string Achivments)
    {
        Achivement_Acompliched = Achivments;
    }
    public void Change_Skins(int[] Skinee)
    {

        string paisArray = "";

            paisArray = Skinee.ToString();

        // Substitui o caracter via índice

        // Junta novamente todos os caracteres em uma string
        Achivement_Acompliched = paisArray;

    }
    public void Change_Skins2(ulong Skinee)
    {

        string paisArray = "";



        paisArray = Skinee.ToString();



        int num2 = Skin_Max - paisArray.Length + 1;

        for (int i = 0; i < (num2); i++)
        {
            paisArray = "0" + paisArray;
        }



        // Substitui o caracter via índice
        // Junta novamente todos os caracteres em uma string
        Skins = paisArray;

    }


}
