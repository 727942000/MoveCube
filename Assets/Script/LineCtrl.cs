using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineCtrl : MonoBehaviour
{
    public Transform s1;
    public Transform s2;
    public Text scoreTxet;
    public MainMenu endText;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = (s1.transform.position + s2.transform.position) / 2;
        transform.localScale = new Vector3(s1.transform.position.x - s2.transform.position.x > 0 ? (s1.transform.position.x - s2.transform.position.x) : 0,transform.localScale.y, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("black"))
        {
            //endText.setText();
            MyGameManager.Instance.Notify(eventName.PlayerDead, new PlayerDeadEventArgs { playerName = gameObject.name });
        }
        else if (collision.CompareTag("blue"))
        {
            collision.gameObject.SetActive(false);
            MyGameManager.Instance.Notify(eventName.AddScore, new PlayerDeadEventArgs { playerName = gameObject.name });
        }
    }
}
