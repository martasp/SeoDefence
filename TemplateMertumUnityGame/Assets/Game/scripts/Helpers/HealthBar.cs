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
            Debug.Log("YOU ARE DEAD! Reviving...");
            currentHP = maxHP;
            slider.value = maxHP;
        }
        else Debug.Log("STILL OK");

    }
}