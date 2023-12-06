//using JetBrains.Annotations;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.Mathematics;
//using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class MWCtrl : MonoBehaviour
{
    Transform[] walls;
    Rigidbody2D rb;
    public float speed = 1;
    public Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
        walls = GetComponentsInChildren<Transform>();
        Reset();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -1) * speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -10)
        {
            Destroy(this.gameObject);
            //transform.position = new Vector3(transform.position.x, 15, 0);
            //Reset();
        }
        //score = Convert.ToInt32(scoreText.text);
        //if (score > left && score <= right)
        //{
        //    speed += 0.5f;
        //    rb.velocity = new Vector2(0, -1) * speed;
        //    left = right;
        //    right += 50;
        //}
    }
    private void Reset()
    {
        for (int i = 1; i < walls.Length; i++)
        {
            if (i <= 10)
            {
                walls[i].gameObject.SetActive(true);
            }
            else
            {
                walls[i].gameObject.SetActive(false);
            }
        }
        walls[7].gameObject.SetActive(false);
        walls[8].gameObject.SetActive(false);
        int choose1 = (int)UnityEngine.Random.Range(1.0f, 6.0f);
        int choose2 = (int)UnityEngine.Random.Range(1.0f, 6.0f);
        choose2 = choose1 == choose2 ? (choose2 - 1 + (int)UnityEngine.Random.Range(1.0f, 5.0f)) % 6 + 1 : choose2;
        walls[9].transform.position = walls[choose1].transform.position;
        walls[10].transform.position = walls[choose2].transform.position;
        walls[choose1].gameObject.SetActive(false);
        walls[choose2].gameObject.SetActive(false);
        Debug.Log(choose1 + " " + choose2 + " " + walls.Length);
        if (choose1 - choose2 > 1)
        {
            for (int i = choose2 + 1; i < choose1; i++)
            {
                walls[i].gameObject.SetActive(false);
                walls[9 + i].gameObject.SetActive(true);
            }
        }
    }
}
