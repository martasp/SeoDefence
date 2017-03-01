using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour

{
    public Image myPanel;
    public float fadeTime = 1f;
    void Start()
    {
        myPanel = GetComponent<Image>();
        Debug.Log("Pasiruoses fadinti"+ myPanel.name);
        Invoke("BlackToTransparent",1);
        //PlayerPrefs.SetInt("score", 25);
        //BlackToTransparent();
    }
    public void BlackToTransparent()
    {
        //myPanel.color = new Color(0,0,0,1);
        myPanel.CrossFadeAlpha(0f,fadeTime,true);
    }
    public void TransparentToBlack()
    {
       // myPanel.color = new Color(0, 0, 0, 0);
        myPanel.CrossFadeAlpha(1f, fadeTime, true);
    }

}