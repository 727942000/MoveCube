//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public MainMenu endText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("green") || collision.CompareTag("blue"))
        {
            //Time.timeScale = 0;
            //SceneManager.LoadScene(0);
            endText.setText();
        }
    }
}
