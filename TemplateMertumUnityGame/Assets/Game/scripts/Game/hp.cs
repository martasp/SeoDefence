using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour {

    // Use this for initialization\
    public int maxHP;
    public int CurrentHP;
    private SpriteRenderer img;

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
            GameObject.Find("Money").GetComponent<MoneyScript>().Add(50); //gets money for one kills
            Destroy(this.gameObject);
        }
    }
}
