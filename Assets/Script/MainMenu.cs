using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour,IObserver
{
    public int score;
    public int maxScore;
    public GameObject end;
    public Text GameScore;
    public Text tx1;
    public Text tx2;
    public GameObject pause;
    public GameObject pauseButtom;
    public GameObject scoreImg;
    // Start is called before the first frame update
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("MAX", 0);
        MyGameManager.Instance.AddObserver(eventName.PlayerDead, this);
    }
    private void OnDestroy()
    {
        MyGameManager.Instance.RemoveObserver(eventName.PlayerDead, this);
    }
    public void ResponseToNotify(EventArgs e)
    {
        setText();
    }
    
    public void setText()
    {
        score =Convert.ToInt32(GameScore.text);
        Time.timeScale = 0;
        end.SetActive(true);
        maxScore = maxScore >= score ? maxScore : score;
        PlayerPrefs.SetInt("MAX",maxScore);
        tx1.text = "" + score;
        tx2.text = "" + maxScore;
        pauseButtom.SetActive(false);
        scoreImg.SetActive(false);
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
    public void Pause()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
        pauseButtom.SetActive(false);
    }
    public void GameContinue()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        pauseButtom.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
