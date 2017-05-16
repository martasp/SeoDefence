using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour {

    // Use this for initialization\
    public int maxHP;
    public int CurrentHP;
    private SpriteRenderer img;
    public int moneyForKill = 50; //how much head of the enemy is worth
    
    void Start()
    {
        img = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHP < 1)
        {
            var alpha = img.color.a;
            var delta = img.color.a * Time.deltaTime * 10;
            img.color = new Color(1f, 1f, 1f, alpha - delta);
            if (transform.childCount > 0)
                for (int i = 0; i < transform.childCount; i++)
                    this.gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha - delta);
        }
        if (img.color.a < 0.01f)
        {
            if (transform.childCount > 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                    Destroy(this.gameObject.transform.GetChild(i).gameObject);
            }
            GameObject.Find("Money").GetComponent<MoneyScript>().Add(moneyForKill); //gets money for one kills
            GameObject.Find("GameManager").GetComponent<AchievmentManager>().addMoneyEarned(moneyForKill);
            if (GameObject.Find("GameManager").GetComponent<AchievmentManager>().checkMoneyEarned())
                GameObject.Find("monopolist").GetComponent<onScreenAchievment>().showUp();
            GameObject.Find("ScoresUI").GetComponent<ScoreManager>().AddScore(25); //get score for one kill
            if (this.gameObject.layer == 9)
            {
                GameObject.Find("GameManager").GetComponent<AchievmentManager>().addPlaneKill(); //add plane kills in achievments
                if (GameObject.Find("GameManager").GetComponent<AchievmentManager>().checkPlaneKills())
                    GameObject.Find("pearlHarbour").GetComponent<onScreenAchievment>().showUp();
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<AchievmentManager>().addKillCount(); //add enemy kills in achievments
                if (GameObject.Find("GameManager").GetComponent<AchievmentManager>().checkKillcount())
                    GameObject.Find("massacre").GetComponent<onScreenAchievment>().showUp();
            }
            if (GameObject.Find("GameManager").GetComponent<AchievmentManager>().checkKilled())
                GameObject.Find("dDay").GetComponent<onScreenAchievment>().showUp();
            Destroy(this.gameObject);
        }
    }
}
