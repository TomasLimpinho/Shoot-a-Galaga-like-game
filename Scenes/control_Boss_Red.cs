using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_Boss_Red : MonoBehaviour
{
    public Transform prefab;
    public Transform prefab2;

    public Vector3 Spawn_Location;

    public float fireRate;
    private float nextFire = 0f;

    public float ShootingRate;
    private float nextShooting = 0f;

    public int Bullet_max = 10;
    public int Bullet_number = 0;

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
        nextFire = Random.Range(0.0f, 5.0f);
    }
    void Update()
    {

            if (Bullet_number < Bullet_max)
            {
                if (nextFire <= Time.time)
                {
                    Spawn_Location = transform.position + new Vector3(0, -1, 0);
                //            Transform bullet = Instantiate(prefab, Spawn_Location, Quaternion.identity);

                //   Transform bullet = Instantiate(prefab, Spawn_Location, Quaternion.RotateTowards(transform.rotation, GameObject.FindGameObjectWithTag("Hero").transform.rotation, 100 * Time.deltaTime));
                //   Debug.Log("Hero found: rotation found + " + Quaternion.RotateTowards(transform.rotation, GameObject.FindGameObjectWithTag("Hero").transform.rotation, 100 * Time.deltaTime));

                Vector3 targetDir = GameObject.FindGameObjectWithTag("Hero").transform.position - transform.position;

                // The step size is equal to speed times frame time.
                float step = 100 * Time.deltaTime;

                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
                //Debug.DrawRay(transform.position, newDir, Color.red);

                // Move our position a step closer to the target.


                Transform bullet = Instantiate(prefab, Spawn_Location, Quaternion.identity);
                // bullet.rotation = Quaternion.LookRotation(newDir);
                bullet.rotation = Quaternion.Euler(0, 0, newDir.z);

                nextFire = Time.time + fireRate;
                    Bullet_number++;
                }
            }
            else
            {
                Bullet_number = 0;
                nextShooting = Time.time + ShootingRate;

                //spawn special bullet afeter de normal ones

                Spawn_Location = transform.position + new Vector3(0, -1, 0);
                Transform bullet = Instantiate(prefab2, Spawn_Location, Quaternion.identity);
                nextFire = Time.time + fireRate;
                Bullet_number++;

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
        Game_Manager.instance.Add_Score_Now2(500);
    }
}
