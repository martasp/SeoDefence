using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    private bool pause;
    private void Start()
    {
        pause = false;
        UnPause();
    }
    private void DoPause()
    {
        Time.timeScale = 0.0000001f;
        pause = true;
    }
    private void UnPause()
    {
        Time.timeScale = 1f;
        pause = false;
    }
    public void ToglePause()
    {

        if (pause)
        {
            UnPause();
        }
        else
        {
            DoPause();

        }
    }
}
