using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Filler : MonoBehaviour {

	// Use this for initialization

	public float gameMaxRasalas;
	public float esamas;
	private Image img;

	void Start () {
        esamas = PlayerPrefs.GetInt("ManoRasalas");
        //PlayerPrefs.SetInt ("ManoRasalas",30);
		gameMaxRasalas = PlayerPrefs.GetInt ("ManoRasalas");
		img = gameObject.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		esamas = PlayerPrefs.GetInt ("ManoRasalas");
		float ats = esamas / gameMaxRasalas;
		img.fillAmount = ats;
	}


}
