using SonicBloom.Koreo;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    public string eventID;//�¼�ID��֮ǰ���õ��Ǹ�ID
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
