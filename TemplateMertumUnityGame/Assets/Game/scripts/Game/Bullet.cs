using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public bool fired = false;
    public float flashTime = 0.5F;
    public SpriteRenderer bullet;
    public GameObject e;
	// Use this for initialization
	void Start () {
        bullet = GetComponent<SpriteRenderer>();

	}

    public void see()
    {
        gameObject.SetActive(true);
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
