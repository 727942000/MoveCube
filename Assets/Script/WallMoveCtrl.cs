using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallMoveCtrl : MonoBehaviour
{
    private float speed = 1.0f;
    private Rigidbody2D rb;
    public Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -1) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        score = Convert.ToInt32(scoreText.text);
        if (score > 50 && score <= 100)
        {
            speed = 1.5f;
            rb.velocity = new Vector2(0, -1) * speed;
        }
        else if (score > 100 && score <= 300)
        {
            speed = 2.0f;
            rb.velocity = new Vector2(0, -1) * speed;
        }
        if (score >= 300)
        {
            speed = 3.0f;
            rb.velocity = new Vector2(0, -1) * speed;
        }
    }
}
