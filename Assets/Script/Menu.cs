//using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public int maxScore;
    public Text maxText;
    // Start is called before the first frame update
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("MAX", 0);
        maxText.text = "当前最好成绩:" + maxScore;
        //Time.timeScale = 0;
    }
    public void GamePlay()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

}
