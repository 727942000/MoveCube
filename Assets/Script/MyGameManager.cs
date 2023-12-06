using System;
using System.Collections.Generic;
using UnityEngine;
public class MyGameManager
{
    //����ģʽ
    private static MyGameManager instance;
    public static MyGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MyGameManager();
            }
            return instance;
        }
    }
    private Dictionary<string, List<IObserver>> observerDic = new Dictionary<string, List<IObserver>>();

    //��ӹ۲���
    public void AddObserver(string eventName,IObserver observer)
    {
        if (observerDic.ContainsKey(eventName))
        {
            observerDic[eventName].Add(observer);
        }
        else
        {
            observerDic.Add(eventName, new List<IObserver> { observer });
        }
    }
    //�Ƴ�
    public void RemoveObserver(string eventName,IObserver observer)
    {
        if (observerDic.ContainsKey(eventName))
        {
            observerDic[eventName].Remove(observer);
        }
    }
    //����֪ͨ
    public void Notify(string eventName,EventArgs e)
    {
        if (observerDic.ContainsKey(eventName))
        {
            foreach(var ob in observerDic[eventName]){
                ob.ResponseToNotify(e);
            }
        }
    }


}
