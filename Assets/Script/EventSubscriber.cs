using SonicBloom.Koreo;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    public string eventID;//事件ID，之前设置的那个ID
                          // Use this for initialization
    public GameObject go;
    void Start()
    {
        Koreographer.Instance.RegisterForEvents(eventID, FireEventDebugLog);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FireEventDebugLog(KoreographyEvent koreoEvent)
    {
        
        Instantiate(go);
    }
}
