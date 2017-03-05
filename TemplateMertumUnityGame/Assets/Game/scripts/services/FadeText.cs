using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour {
    public float fadeTime;
    public float invokeAfterTime;
    void Start()
    {
        Invoke("crosFadeThisTextNow", invokeAfterTime);
    }
    public void crosFadeThisTextNow()
    {
        GetComponent<Text>().CrossFadeAlpha(0f, fadeTime, true);
    }
}
