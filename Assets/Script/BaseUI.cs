using System;
using UnityEngine;

public class BaseUI : MonoBehaviour,IObserver
{
    // Start is called before the first frame update
    public virtual void ResponseToNotify(EventArgs e) { }
    //��ʼ������(����д)
    public virtual void Init() { }
    //����
    public void DisActiveUI() { gameObject.SetActive(false); }
    //��ʾ
    public void ActiveUI() { gameObject.SetActive(true); }
    //����UI
    public void DestroyUI() { GameObject.Destroy(gameObject); }
}
