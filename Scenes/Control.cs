using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Transform prefab;
    public Vector3 Spawn_Location;
    public float fireRate = 1f;
    public float nextFire = 1f;
    public int Skin_Atual = 0;

    private SpriteRenderer spriteR;

    public Sprite[] Hero_Skins;

    public float tamanho = 5f;

    void Awake()
    {
        this.name = "hero";
        Game_Manager.instance.Cria_Nave("hero", 100, "hero");

        spriteR = gameObject.GetComponent<SpriteRenderer>();

        Skin_Atual = Savings.instance.Show_Skin_Atual();
        spriteR.sprite = Hero_Skins[Skin_Atual];
        spriteR.size = new Vector2(tamanho, tamanho);
    }

    void Update()
    {     
        if (nextFire <= Time.time)
        {
            Spawn_Location = transform.position + new Vector3(0, 5, 0);
            Transform bullet = Instantiate(prefab, Spawn_Location, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

}
