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
        Debug.Log("Pasiruoses fadinti "+ myPanel.name);
        Invoke("BlackToTransparent",1);
    }
    public void BlackToTransparent()
    {
        myPanel.CrossFadeAlpha(0f,fadeTime,true);
    }
    public void TransparentToBlack()
    {
        myPanel.CrossFadeAlpha(1f, fadeTime, true);
    }

}