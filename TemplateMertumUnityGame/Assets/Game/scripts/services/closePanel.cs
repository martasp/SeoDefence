using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closePanel : MonoBehaviour {

    public Canvas panel;

	public void Open ()
    {
        panel.GetComponent<Canvas>().enabled = true;
    }
    public void Close ()
    {
        panel.GetComponent<Canvas>().enabled = false;
    }
}
