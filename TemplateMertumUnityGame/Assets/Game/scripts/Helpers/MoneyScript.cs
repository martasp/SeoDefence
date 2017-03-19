using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {
    public int money = 300;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Add(int amount)
    {
        Text text = GetComponent<Text>();
        money += amount;
        text.text = money.ToString();
    }

    public void Sub(int amount)
    {
        if (amount > money)
            return;
        Text text = GetComponent<Text>();
        money -= amount;
        text.text = money.ToString();
    }
}
