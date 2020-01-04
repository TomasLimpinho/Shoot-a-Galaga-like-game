using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acel : MonoBehaviour
{
    public float SPEED = 1;
    private Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
            if (Input.GetMouseButton(0))
            {
                checkTouch(Input.mousePosition);
            }
            else if(Input.GetAxis("Horizontal") < 0f)
            {
            SlideLeft();
            }
            else if (Input.GetAxis("Horizontal") > 0f)
            {
                SlideRight();
            }

    }

    private void checkTouch(Vector2 pos)
    {
            if (pos.x < Screen.width/2)
            {
                SlideLeft();
            }
            else if (pos.x > Screen.width / 2)
            {
                SlideRight();
            }

    }

    public void SlideLeft()
    {
        rb2D.velocity = (new Vector2(-1, 0) * SPEED);
    }

    public void SlideRight()
    {
        rb2D.velocity = (new Vector2(1, 0) * SPEED);
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
    }
}
