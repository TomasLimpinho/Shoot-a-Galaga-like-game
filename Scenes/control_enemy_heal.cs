using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_enemy_heal : MonoBehaviour
{
    public Transform prefab;

    public Vector3 Spawn_Location;

    public float fireRate;
    private float nextFire = 0f;


    public float MoveRate = 5f;
    private float Movechange = 0f;
    public float SPEED = 10;

    private Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        nextFire = Random.Range(0.0f, 10.0f) + Time.time;
    }
    void Update()
    {

        if (nextFire <= Time.time)
        {
            Spawn_Location = transform.position + new Vector3(0, -5, 0);
            Transform bullet = Instantiate(prefab, Spawn_Location, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
        if (Movechange <= Time.time)
        {
            SPEED = 0 - SPEED;
            rb2D.velocity = (new Vector2(1, 0) * SPEED);
            Movechange = Time.time + MoveRate;
        }
    }
    private void OnDestroy()
    {
        Game_Manager.instance.health_Nave("hero", 50);
        Game_Manager.instance.Add_Score_Now2(50);
        //Debug.Log("healed");
    }

}
