using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float thrust = 10.0f;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2D.velocity = (transform.up * thrust);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "hero" && col.gameObject.tag != "Bullet" && col.gameObject.tag != "Wall")
        {
            Destroy(gameObject);
            Game_Manager.instance.Shoot_Sound_ON_And_OFF(1);
            if ((Game_Manager.instance.health_Nave(col.gameObject.name, -10) <= 0) && (col.gameObject.name != "hero"))
            {
                Destroy(col.gameObject);
            }
        }
        else if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
