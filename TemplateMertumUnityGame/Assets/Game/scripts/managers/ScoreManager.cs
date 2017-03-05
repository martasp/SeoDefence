using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highscoreText;
	public void StoreHighscore(int newHighscore)
	{
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);  
		PlayerPrefs.SetInt("score", newHighscore);
		if(newHighscore > oldHighscore)
		{
			PlayerPrefs.SetInt("highscore", newHighscore);
			highscoreText = scoreText;
			PlayerPrefs.Save();
		}
	}
	public void StoreMoney(int money)
	{
		PlayerPrefs.SetInt("money", money);
	}
	public string HscoreGet()
	{
		return PlayerPrefs.GetInt("highscore", 0).ToString(); 
	}
	public string scoreGet()
	{
		return PlayerPrefs.GetInt("score",0).ToString(); 
	}
	public void DisplayHscore()
	{
		highscoreText.text = HscoreGet ();
	}
	public void Displayscore()
	{
		scoreText.text = scoreGet ();
	}

	void Start()
	{
		Displayscore ();
		DisplayHscore ();
	}
	void Update()
	{
	//	Displayscore ();
	//	DisplayHscore ();
	}


}