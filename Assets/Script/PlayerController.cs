//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
using System;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed = 5;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public Text scoreTxet;
    public MainMenu endText;
    private Vector2 mousePos;
    private Vector2 distance;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Input.multiTouchEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        int direction = 0;
        if (Input.GetKey(left))
        {
            direction -= 1;
        }
        if (Input.GetKey(right)){
            direction += 1;
        }
        if((transform.position.x >= 7.5 && direction == 1) || (transform.position.x <= -7.5 && direction == -1))
        {
            direction = 0;
        }

        rb.velocity = new Vector2(direction, 0) * speed;
        var mp = Input.mousePosition;
        mp.z = Mathf.Abs(Camera.main.transform.position.z);
        //mousePos = Camera.main.ScreenToWorldPoint(mp);
        mousePos = Camera.main.ScreenToViewportPoint(mp);
        //Debug.Log(mousePos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("black") || collision.CompareTag("blue"))
        {
            //endText.setText();
            MyGameManager.Instance.Notify(eventName.PlayerDead,new PlayerDeadEventArgs { playerName = gameObject.name});
        }
        else if(collision.CompareTag("green"))
        {
            //collision.gameObject.GetComponent<WallCtrl>().canElim = true;
            collision.transform.parent.GetComponent<WallCtrl>().canElim = true;
            MyGameManager.Instance.Notify(eventName.Eliminate, new PlayerDeadEventArgs { playerName = gameObject.name });
            
            collision.gameObject.SetActive(false);
            MyGameManager.Instance.Notify(eventName.AddScore, new PlayerDeadEventArgs { playerName = gameObject.name });
            //int count = (Convert.ToInt32(scoreTxet.text) + 5);
            //StringBuilder sb = new StringBuilder();
            //sb.Append(count);
            //Debug.Log(sb.ToString());
            //scoreTxet.text = sb.ToString();
        }
    }
    private void OnMouseDown()
    {
        distance = mousePos;
        //Debug.Log("1: " + "distance" + distance + " mouse" + mousePos);
    }
    private void OnMouseDrag()
    {
        //Debug.Log("2:" + "distance" + distance + " mouse" + mousePos);
        distance = mousePos - distance;
        if (distance.x > 1 || distance.x < -1)
        {
            distance = new Vector2(0, 0);
        }
        //Debug.Log("distance" + distance);
        transform.position = new Vector2(transform.position.x, transform.position.y) +  (transform.position.x >=-7.5&& distance.x < 0 || transform.position.x <= 7.5 && distance.x > 0 ? new Vector2(distance.x * 20, 0) : new Vector2(0f,0f));
        distance = mousePos;
    }

}
