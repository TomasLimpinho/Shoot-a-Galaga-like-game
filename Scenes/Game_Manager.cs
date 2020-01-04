using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance = null;

    public int Boss_Spawn_Levels_Multi = 5; //Boss Spawn from x level in x levels

    public GameObject Background_Principal;

    public string Background_LastBoss_Name = "Inicial";

    public GameObject Background_LastBoss;

    private Transform Two;

    public GameObject bj;

    public int Level = 0;

    public int Enemy_generated = -1;

    public GameObject[] backgrounds;

    public Transform prefab;

    public Transform prefab2;

    public Transform prefab3;

    public Transform Hero;

    public Transform Boss_Blue; 

    public Transform Boss_Red;

    public Transform Boss_Purple;

    public int Score_Highest = 1;

    public int Score_Highest2 = 0;

    public int Score_Now = 0;

    public int Score_Now2 = 0;

    public Text Pause_Text_Score_Highest;

    public Text Pause_Text_Score_Now;

    public Text Pause_Text_Score_Highest2; 

    public Text Pause_Text_Score_Now2;

    public string[] Boss_Names = {"BLUE", "RED", "PURPLE" };

    public int House_Mode = 1; // House screen ON/OFF

    public struct Nave
    {
        public int life;
        public int maxlife;
        public string Name;
    }
      
    public Dictionary<string, Nave> Playes = new Dictionary<string, Nave>();

    public AudioSource Shoot_Sound;

    public AudioSource Music_background_1;

    public AudioSource Music_Boss_Blue;

    public AudioSource Music_Boss_Red;

    public AudioSource Music_Boss_Purple;

    public int Starting2 = 1;

    public void Start()
    {
        Shoot_Sound = GetComponent<AudioSource>();

        Music_background_1.Play(1);

    }

    public void Shoot_Sound_ON_And_OFF(ulong i)
    {
        Shoot_Sound.Play(i);     
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Update()
    {
        GameObject[] gos;
        GameObject[] gos2;

        gos = GameObject.FindGameObjectsWithTag("Enemy");
        gos2 = GameObject.FindGameObjectsWithTag("Hero");



        if (gos.Length == 0)
        {

            Achivments.instance.AnalizarAchivements();

            Score_Now++;
            Delete_Bullets();

            Savings.instance.Save(Score_Now, Score_Now2);

            Pause_Text_Score_Highest.text = "HIGH LEVEL :   " + Savings.instance.Show_Score_Highest();
            Pause_Text_Score_Now.text = "LEVEL :   " + Score_Now;

            Pause_Text_Score_Highest2.text = "HIGH SCORE :   " + Savings.instance.Show_Score_Highest2();
            Pause_Text_Score_Now2.text = "SCORE :   " + Score_Now2;

            Level_Change();
        }
        else if ((gos2.Length == 0) && (Level != 0))
        {

            Achivments.instance.AnalizarAchivements();

            //Debug.Log("You Lose!");
            Savings.instance.Save(Score_Now , Score_Now2);
           

            Pause_Text_Score_Highest.text = "HIGH LEVEL :   " + Savings.instance.Show_Score_Highest();
            Pause_Text_Score_Now.text = "LEVEL :   " + Score_Now;

            Pause_Text_Score_Highest2.text = "HIGH SCORE :   " + Savings.instance.Show_Score_Highest2();
            Pause_Text_Score_Now2.text = "SCORE :   " + Score_Now2;

            Score_Now = 0;
            Score_Now2 = 0;
            Level = 0; 
            Level_Clean();

            House_Mode_Change(1); //I am using this?????

            Level_Change();   //alterar esta parte do codigo
        }
       // Savings.instance.Save(Score_Now, Score_Now2);

        Pause_Text_Score_Highest2.text = "HIGH SCORE :   " + Savings.instance.Show_Score_Highest2();
        Pause_Text_Score_Now2.text = "SCORE :   " + Score_Now2;             
    }

    public void Delete_Bullets()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < gos.Length; i++)
        {
            Destroy(gos[i]);
        }
    }

    public void Level_Clean()
    {
        Debug.Log("You ar doing cleaninnnnnnn the level");
        Delete_Bullets();
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < gos.Length; i++)
        {
            Destroy(gos[i]);
        }

        Debug.Log("Cleaning the level");

        
        Starting.instance.PauseGame();

        //Avisar a barra de vida que estamos fora do jogo
        Starting2 = 1;

        //Changing background to incial again
        bj = GameObject.Find("Background_Inicial");
        if (bj != null)
        {
            Music_background_1.Play(1);
            Music_Boss_Blue.Stop();
            Music_Boss_Red.Stop();
            Music_Boss_Purple.Stop();

            Background_LastBoss.transform.position = new Vector3(0.6f, 0.7f, 2.5f);
            bj.transform.position = new Vector3(-2.6f, -476.7f, 2f);
        }
        //background change ends here



}
    public void Generate_Hero()
    {
        Instantiate(Hero, new Vector2(-2.8f, -489.9f), Quaternion.identity);
        health_set_Nave("hero", 100);
        health_Max_set_Nave("hero", 100);
    }
    public void Background_Changing()
    {

        if (Background_LastBoss_Name == "Nebula_Blue")
        {
            bj = GameObject.Find("Background_Blue");

            Music_background_1.Play(1);
            Music_Boss_Blue.Stop();
            Music_Boss_Red.Stop();
            Music_Boss_Purple.Stop();
        }
        else if (Background_LastBoss_Name == "Nebula_Red")
        {
            bj = GameObject.Find("Background_Red");

            Music_background_1.Play(1);
            Music_Boss_Red.Stop();
        }
        else if (Background_LastBoss_Name == "Nebula_Purple")
        {
            bj = GameObject.Find("Background_Purple");

            Music_background_1.Play(1);
            Music_Boss_Purple.Stop();
        }
        else
        {
            bj = GameObject.Find("Background_Inicial");

            Music_background_1.Play(1);
            Music_Boss_Blue.Stop();
            Music_Boss_Red.Stop();
            Music_Boss_Purple.Stop();
        }
        Background_LastBoss.transform.position = new Vector3(0.6f, 0.7f, 2.5f);
        bj.transform.position = new Vector3(-2.6f, -476.7f, 2f);
    }

    public void Level_Boss()
    {
        if(Level != Boss_Spawn_Levels_Multi) { bj.transform.position = new Vector3(-0.6f, -0.7f, 2.5f); }
        backgrounds = GameObject.FindGameObjectsWithTag("Background_Boss");

        int w = Random.Range(0, backgrounds.Length);


        backgrounds[w].transform.position = new Vector3(-2.6f, -476.7f, 2f);
        Background_LastBoss = backgrounds[w];
        Background_LastBoss_Name = backgrounds[w].name;


        //Spawning The Boss
        if (Background_LastBoss_Name == "Nebula_Blue")
        {
             Two = Instantiate(Boss_Blue.transform, new Vector3(-2.586215f, -464f, 0f), Quaternion.identity);
            Two.name = Boss_Names[1];

            Music_background_1.Pause();
            Music_Boss_Blue.Play(1);
        }
        else if (Background_LastBoss_Name == "Nebula_Red")
        {
             Two = Instantiate(Boss_Red.transform, new Vector3(-2.586215f, -464f, 0f), Quaternion.identity);
            Two.name = Boss_Names[0];

            Music_background_1.Pause();
            Music_Boss_Red.Play(1);
        }
        else if (Background_LastBoss_Name == "Nebula_Purple")
        {
            Two = Instantiate(Boss_Purple.transform, new Vector3(-2.586215f, -464f, 0f), Quaternion.identity);
            Two.name = Boss_Names[2];

            Music_background_1.Pause();
            Music_Boss_Purple.Play(1);
        }

       // Two.name = "enemy_" + Enemy_generated;
       //two enemy is the enemy "boss"
               Cria_Nave(Two.name, 500, Two.name); //escolher nome do boss
        Two.tag = "Enemy";
        
    }

    public void Level_Change()
    {

        Level++;
        
        if((Level % Boss_Spawn_Levels_Multi) == 0)
        {
            Level_Boss();
        }
        else 
        {
            if (Level == 1) {
                Generate_Hero();
            }
            else if ((Level == Boss_Spawn_Levels_Multi +  1) || (( (Level -1) % (Boss_Spawn_Levels_Multi) ) == 0))
            {
                Background_Changing();
            }

            float x = -15f;
            float y = -455f;

            int Spawned = 0;

            Transform One = Instantiate(prefab, new Vector2(x, y), Quaternion.identity);

            One.name = "enemy_" + Enemy_generated;
            Cria_Nave(One.name, 30, One.name);

            for (int i = 1; (Spawned <= (Level * 3)) && ((y - i * 5) > -490f); i++)
            {

                for (int j = 1; (j <= 5) && (Spawned <= Level * 3) && (x + j * 10) < 50; j++)
                {
                    float Z = Random.Range(0f, 1f);

                    if (Z < 0.90f) //90 % de ser normal
                    {
                        Two = Instantiate(prefab, new Vector2(x + j * 10, y - i * 5), Quaternion.identity);
                        Two.name = "enemy_" + Enemy_generated;
                        Cria_Nave(Two.name, 30, Two.name);
                    }

                    else if (Z < 0.97f) //7 % de ser healer
                    {
                        Two = Instantiate(prefab2, new Vector2(x + j * 10, y - i * 5), Quaternion.identity);
                        Two.name = "enemy_" + Enemy_generated;
                        Cria_Nave(Two.name, 20, Two.name);
                    }
                    else    //3% de ser max_healer
                    {
                        Two = Instantiate(prefab3, new Vector2(x + j * 10, y - i * 5), Quaternion.identity);
                        Two.name = "enemy_" + Enemy_generated;
                        Cria_Nave(Two.name, 20, Two.name);
                    }


                    Spawned++;
                }
            }
        }

    }

    public int Show_Level()
    {
        return Level;
    }

    public int Show_Boss_Level()
    {
        return Boss_Spawn_Levels_Multi;
    }
    
    public int Show_Life()
    {
        Nave h = Playes["hero"];
        return h.life;
    }

    public int Show_Max_Life()
    {
        Nave h = Playes["hero"];
        return h.maxlife;
    }

    public int Show_Enemy_Generated()
    {
        return Enemy_generated;
    }
    
    public string Show_Enemy_Boss_Name()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        Nave h = Playes[gos[0].name];
        return h.Name;
    }


    public void Cria_Nave(string enemy, int life, string Name)
    {
        Nave h = new Nave();
        Nave h2 = new Nave();

        Enemy_generated++;
        h.life = life;
        h.maxlife = life;
        h.Name = Name;

        if (!Playes.TryGetValue(enemy, out h2))
        {
            Playes.Add(enemy, h);
        }

    }

    public int health_Nave(string enemy, int i)
    {
        Nave h = Playes[enemy];
        if ((Playes[enemy].life + i <= Playes[enemy].maxlife) && (Playes[enemy].life + i >=0))
        {
            h.life = Playes[enemy].life + i;
        }
        else if (Playes[enemy].life + i < 0) { h.life = 0;  }
        else { h.life = Playes[enemy].maxlife; }
        Playes[enemy] = h;

        return h.life;
    }

    public int health_set_Nave(string enemy, int i)
    {
        Nave h = Playes[enemy];
        if (( i <= Playes[enemy].maxlife) && (i >= 0))
        {
            h.life = i;
        }
        else if ( i < 0) { h.life = 0; }
        else { h.life = Playes[enemy].maxlife; }
        Playes[enemy] = h;

        return h.life;
    }

    public int health_Max_Nave(string enemy, int i)
    {
        Nave h = Playes[enemy];
        h.maxlife = Playes[enemy].maxlife + i;
        Playes[enemy] = h;

        return h.maxlife;
    }
    public int health_Max_set_Nave(string enemy, int i)
    {
        Nave h = Playes[enemy];
        h.maxlife = + i;
        Playes[enemy] = h;

        return h.maxlife;
    }
    public int House_Mode_Change(int i)
    {
        House_Mode = i;
        return House_Mode;
    }
    public int Show_House_Mode()
    {
        return House_Mode;
    }
    public void Level_Restart()
    {
        Savings.instance.Save(Score_Now, Score_Now2);


        Pause_Text_Score_Highest.text = "HIGH LEVEL :   " + Savings.instance.Show_Score_Highest();
        Pause_Text_Score_Now.text = "LEVEL :   " + Score_Now;

        Pause_Text_Score_Highest2.text = "HIGH SCORE :   " + Savings.instance.Show_Score_Highest2();
        Pause_Text_Score_Now2.text = "SCORE :   " + Score_Now2;

        Score_Now = 0;
        Level = 0;
        Level_Clean();

        House_Mode_Change(1); //I am using this?????

        Level_Change();   //alterar esta parte do codigo
    }
    public int startingg(int i)
    {
        Starting2 = i;
        return Starting2;
    }
    public int Show_Starting()
    {
        return Starting2;
    }
    public void Add_Score_Now2(int i)
    {
        Score_Now2 += i;
    }
    public void returning_Home()
    {
        Achivments.instance.AnalizarAchivements();

        Savings.instance.Save(Score_Now, Score_Now2);


        Pause_Text_Score_Highest.text = "HIGH LEVEL :   " + Savings.instance.Show_Score_Highest();
        Pause_Text_Score_Now.text = "LEVEL :   " + Score_Now;

        Pause_Text_Score_Highest2.text = "HIGH SCORE :   " + Savings.instance.Show_Score_Highest2();
        Pause_Text_Score_Now2.text = "SCORE :   " + Score_Now2;

        Score_Now = 0;
        Score_Now2 = 0;
        Level = 0;


        Debug.Log("You ar doing cleaninnnnnnn the level");
        Delete_Bullets();
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < gos.Length; i++)
        {
            Destroy(gos[i]);
        }
        gos = GameObject.FindGameObjectsWithTag("Hero");
        for (int i = 0; i < gos.Length; i++)
        {
            Destroy(gos[i]);
        }

        House_Mode_Change(1); //I am using this?????
    }

}
