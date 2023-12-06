using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCtel : MonoBehaviour
{
    private Slider sd;
    private float volumeSize = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        sd = GetComponent<Slider>();
        volumeSize = PlayerPrefs.GetFloat("VOLUME", 0.5f);
        sd.value = volumeSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (sd.value != volumeSize)
        {
            volumeSize = sd.value;
            PlayerPrefs.SetFloat("VOLUME", volumeSize);
        }
    }
}
