using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AddScore : MonoBehaviour,IObserver
{
    // Start is called before the first frame update
    private Text text;
    private void Awake()
    {
        this.text = GetComponent<Text>();
        MyGameManager.Instance.AddObserver(eventName.AddScore,this);
    }
    private void OnDestroy()
    {
        MyGameManager.Instance.RemoveObserver(eventName.AddScore, this);
    }
    public void ResponseToNotify(EventArgs e)
    {
        int count = (Convert.ToInt32(this.text.text) + 5);
        StringBuilder sb = new StringBuilder();
        sb.Append(count);
        Debug.Log(sb.ToString());
        this.text.text = sb.ToString();
    }
}
