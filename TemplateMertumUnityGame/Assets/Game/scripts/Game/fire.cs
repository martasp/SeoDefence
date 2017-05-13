using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{

    public float procentage = 0.20f;
    private bool burn = false;

    // Use this for initialization
    void Start()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (burn == false)
            if (this.gameObject.GetComponent<hp>().CurrentHP <= this.gameObject.GetComponent<hp>().maxHP * procentage)
            {
                burn = true;
                this.transform.GetChild(0).gameObject.SetActive(true);
            }
    }
}