using System;
using UnityEngine;

public class BaseUI : MonoBehaviour,IObserver
{
    // Start is called before the first frame update
    public virtual void ResponseToNotify(EventArgs e) { }
    //初始化方法(可重写)
    public virtual void Init() { }
    //隐藏
    public void DisActiveUI() { gameObject.SetActive(false); }
    //显示
    public void ActiveUI() { gameObject.SetActive(true); }
    //销毁UI
    public void DestroyUI() { GameObject.Destroy(gameObject); }
}
