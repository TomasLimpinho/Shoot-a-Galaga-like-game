using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_Boss_Purple : MonoBehaviour
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
        nextFire = Random.Range(0.0f, 5.0f);
    }
    void Update()
    {

        if (nextFire <= Time.time)
        {
            Spawn_Location = transform.position + new Vector3(0, -1, 0);

            Vector3 targetDir = GameObject.FindGameObjectWithTag("Hero").transform.position - transform.position;

            // The step size is equal to speed times frame time.
            float step = 100 * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            
            // Move our position a step closer to the target.


            Transform bullet = Instantiate(prefab, Spawn_Location, Quaternion.identity);

            bullet.rotation = Quaternion.Euler(0, 0, newDir.z);

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
        Game_Manager.instance.Add_Score_Now2(500);
    }
}
