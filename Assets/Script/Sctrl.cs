//using System.Collections;
//using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class Sctrl : MonoBehaviour
{
    private AudioSource au;
    public AudioSource backAu;
    public MainMenu end;
    // Start is called before the first frame update
    void Start()
    {
        au = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        backAu.volume = PlayerPrefs.GetFloat("VOLUME", 0.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("green"))
        {
            au.Play();
        }
    }
    
}
