using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class endUI : BaseUI
{
    
    private void Awake()
    {
        MyGameManager.Instance.AddObserver(eventName.PlayerDead, this);
        Debug.Log("ря╬╜╪сть");
    }
    private void OnDisable()
    {
        MyGameManager.Instance.RemoveObserver(eventName.PlayerDead, this);  
    }
    public override void ResponseToNotify(EventArgs e)
    {
        ActiveUI();
    }
}
