using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra_Vida : MonoBehaviour
{
    // Draws a texture on the screen at 10, 10 with 100 width, 100 height.

    public Texture aTexture;
    public int x = 10;
    public float y = 30;
    public int height = 50;
    public float width = 100f;
    public float width_Max = 1900f;
    public float Health_Max = 190f;
    public Camera Cam;

    void OnGUI()
    {
       Vector3 bottomLeftWorld = Cam.ViewportToWorldPoint(new Vector3(0, Screen.height, 0));

        y = bottomLeftWorld.y;

        if (Game_Manager.instance.Show_Starting() == 0)
        {
            width = Game_Manager.instance.Show_Life();
            Health_Max = Game_Manager.instance.Show_Max_Life();

            width = width / Health_Max;

            if (width < 0f) { width = 0f; }
            else if (width > 1) { width  = 1f; }
            Debug.Log("widht: " + width);
      //  Mathf.Lerp(0, 0.9, width);

            if (Event.current.type.Equals(EventType.Repaint))
            {
                Graphics.DrawTexture(new Rect((float)Screen.width / 10, (float)Screen.height - (float)Screen.height / 10 , (float)Screen.width * width , (float)Screen.height), aTexture);
            }
        }
        else
        {
            Graphics.DrawTexture(new Rect(0, 0, 0, 0), aTexture);
        }
    }
}
