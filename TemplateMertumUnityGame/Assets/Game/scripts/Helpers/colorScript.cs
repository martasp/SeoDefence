using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorScript : MonoBehaviour {
    public Text progress;
    // Use this for initialization
    void Start () {
        GameObject.Find("list").GetComponent<AchievmentManager>().Display();
        if (check())
        {
            this.gameObject.GetComponent<Image>().color = new Color(82f, 223f, 0f, 175f);
        }
	}
	public bool check ()
    {
        string line = progress.text;
        Debug.Log(line);
        if (line.Contains(" / "))
            return false;
        return true;
    }
}
