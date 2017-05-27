using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    private Fader transition;
    void Start()
    {
       // Debug.Log("uzkrauti screen fader");
        //transition = GameObject.Find("imgFader").GetComponent<Fader>();
    }

    #region UIManaging
    public void PlayGameSceneAsync()
    {
        transition = GameObject.Find("imgFader").GetComponent<Fader>();
        Debug.Log("opening PlayGameScene" );
        Invoke("PlayGameScene", transition.fadeTime);
        transition.TransparentToBlack();
    }
    public void GameOverSceneAsync()
    {
        transition = GameObject.Find("imgFader").GetComponent<Fader>();
        Debug.Log("opening GameOverScene");
        Invoke("GameOverScene", 1);
        transition.TransparentToBlack();
    }
    public void AchievmentSceneAsync()
    {
        transition = GameObject.Find("imgFader").GetComponent<Fader>();
        Debug.Log("opening AchievmentScene");
        Invoke("AchievmentScene", 1);
        transition.TransparentToBlack();
    }
    public void StartSceneAsync()
    {
        transition = GameObject.Find("imgFader").GetComponent<Fader>();
        Debug.Log("opening StartScene");
        Invoke("StartScene", transition.fadeTime);
        transition.TransparentToBlack();
    }
    public void PlayGameScene()
    {
        SceneManager.LoadScene("PlayGameScene");
        GameObject.Find("ScoresUI").GetComponent<ScoreManager>().resetScore(); 
    }
    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
        GameObject.Find("ScoresUI").GetComponent<ScoreManager>().DisplayHscore();
        GameObject.Find("ScoresUI").GetComponent<ScoreManager>().Displayscore();
    }
    public void AchievmentScene()
    {
        SceneManager.LoadScene("AchievmentScene");
    }
    public void StartScene()
    {
        SceneManager.LoadScene("Start");
    }
    public void openPage ()
    {
        Application.OpenURL("https://www.facebook.com/mertumGStudios/?fref=ts");
    }
    #endregion
    #region GameOver

    #endregion
}
