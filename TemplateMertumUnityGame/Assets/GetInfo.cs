using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInfo : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    var MyName = this.gameObject.name;
	    MyName = MyName.Replace("Base", "");
        Debug.Log(MyName+" ar geras");
	    var Ui = GameObject.Find(MyName+"UI");
	    if (Ui !=null)
	    {
            Ui.transform.Find("Text").GetComponent<Text>().text = this.gameObject.GetComponent<Info>().price.ToString();
        }

	}

}
