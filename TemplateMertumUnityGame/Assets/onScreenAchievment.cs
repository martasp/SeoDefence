using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onScreenAchievment : MonoBehaviour {

    private AudioSource source;
    public bool check = false;
    public Vector3 position;
    // Use this for initialization

    void Start()
    {
        source = GameObject.Find("list").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (check == true)
        {
            check = false;
            showUp();

        }
    }

    IEnumerator wait()
    {
        
        yield return new WaitForSeconds(3);
        this.transform.Translate(position * (-1));
    }

    public void showUp()
    {
        this.transform.Translate(position);
        source.Play();
        StartCoroutine(wait());
        
    }
}
