using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maxHP = 4;
    public int currentHP = 4;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage()
    {
        Slider slider = GetComponent<Slider>();
        currentHP -= 1;
        slider.value = currentHP;
        if (currentHP == 0)
        {
            this.GameOver();
        }
    }
    public void GameOver()
    {
        var manager = this.gameObject.AddComponent<UIManager>();
        GameObject.Find("ScoresUI").GetComponent<ScoreManager>().StoreHighscore(GameObject.Find("ScoresUI").GetComponent<ScoreManager>().getIntScore());
        GameObject.Find("GameManager").GetComponent<AchievmentManager>().checkKilledIOG();
        GameObject.Find("GameManager").GetComponent<AchievmentManager>().addPlayTimes();
        if (GameObject.Find("GameManager").GetComponent<AchievmentManager>().checkPlayTimes())
            GameObject.Find("persistent").GetComponent<onScreenAchievment>().showUp();
        manager.GameOverSceneAsync();
    }
}