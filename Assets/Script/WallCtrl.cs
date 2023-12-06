using JetBrains.Annotations;
using System;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.Mathematics;
//using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class WallCtrl : MonoBehaviour,IObserver
{
    Transform[] walls;
    Rigidbody2D rb;
    public float speed = 1;
    public Text scoreText;
    private int score = 0;
    private int left = 50, right = 100;
    public bool canElim = false;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(Random.Range(-0.5f, 0.5f), transform.position.y, 0);
        walls = GetComponentsInChildren<Transform>();
        Reset();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -1) * speed;
        MyGameManager.Instance.AddObserver(eventName.Eliminate, this); 
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        MyGameManager.Instance.RemoveObserver(eventName.Eliminate, this);
    }
    void Update()
    {
        if (transform.position.y <= -10)
        {
            transform.position = new Vector3(transform.position.x, 15, 0);
            Reset();

        }
        if (scoreText != null)
        { 
            
            score = Convert.ToInt32(scoreText.text);
            if (score <= 100)
            {
                speed = 2;
            }
            else if(score <= 200)
            {
                speed = 3;
            }
            else
            {
                speed = 4;
            }
            rb.velocity = new Vector2(0, -1) * speed;
        }
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
        //Debug.Log(choose1 + " " + choose2 + " " + walls.Length);
        if(choose1 - choose2 > 1)
        {
            for(int i = choose2 + 1;i < choose1; i++)
            {
                walls[i].gameObject.SetActive(false);
                walls[9 + i].gameObject.SetActive(true);
            }
        }
        
    }
    public void ResponseToNotify(EventArgs e)
    {
        if (!canElim)
        {
            return;
        }
        canElim = false;
        float pos1 = walls[9].transform.position.x;
        float pos2 = walls[10].transform.position.x;
        for(int i = 1;i <= 6; i++)
        {
            if (!(walls[i].transform.position.x > pos1 && walls[i].transform.position.x < pos2))
            {
                walls[i].gameObject.SetActive(false);
            }
        }
    }

}
