using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private Fader transition;

    void Start()
    {
        transition = GameObject.Find("imgFader").GetComponent<Fader>();
    }

    #region UIManaging
    public void PlayGameSceneAsync()
    {
        Invoke("PlayGameScene", transition.fadeTime);
        transition.TransparentToBlak();
    }
    public void GameOverSceneAsync()
    {
        Invoke("GameOverScene", transition.fadeTime);
        transition.TransparentToBlak();
    }
    public void ShopSceneAsync()
    {
        transition.TransparentToBlak();
        Invoke("ShopScene", transition.fadeTime);
    }
    public void StartSceneAsync()
    {
        Invoke("StartScene", transition.fadeTime);
        transition.TransparentToBlak();
    }
    public void PlayGameScene()
    {
        SceneManager.LoadScene("PlayGameScene");
    }
    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void ShopScene()
    {
        SceneManager.LoadScene("Shop");
    }
    public void StartScene()
    {
        SceneManager.LoadScene("Start");
    }
    #endregion
    #region GameOver

    #endregion
}
