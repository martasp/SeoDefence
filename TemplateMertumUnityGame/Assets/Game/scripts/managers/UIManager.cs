using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    private Fader transition;
    void Start()
    {
        transition = GameObject.Find("imgFader").GetComponent<Fader>();
    }

    #region UIManaging
    public void PlayGameSceneAsync()
    {
        Debug.Log("opening PlayGameScene" );
        Invoke("PlayGameScene", transition.fadeTime);
        transition.TransparentToBlack();
    }
    public void GameOverSceneAsync()
    {
        Debug.Log("opening GameOverScene");
        Invoke("GameOverScene", transition.fadeTime);
        transition.TransparentToBlack();
    }
    public void ShopSceneAsync()
    {
        Debug.Log("opening ShopScene");
        transition.TransparentToBlack();
        Invoke("ShopScene", transition.fadeTime);
    }
    public void StartSceneAsync()
    {
        Debug.Log("opening StartScene");
        Invoke("StartScene", transition.fadeTime);
        transition.TransparentToBlack();
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
