using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {
    public int money = 5000;

	// Use this for initialization
	void Start ()
	{
	    InitMoney();
	}

    private void InitMoney()
    {
        PlayerPrefs.SetInt("Money", money);
        money = PlayerPrefs.GetInt("money");
        SetMoneyInView();
    }

    private void SetMoneyInView()
    {
        var text = this.GetComponent<Text>();
        text.text = money.ToString();
        PlayerPrefs.SetInt("Money", money);
    }

    // Update is called once per frame
	void Update () {
		
	}

    public void Add(int amount)
    {
        money += amount;
        SetMoneyInView();
    }

    public bool Sub(int amount)
    {
        if (amount > money)
        {
            return false;
        }
        money -= amount;
        SetMoneyInView();
        return true;
    }
}
