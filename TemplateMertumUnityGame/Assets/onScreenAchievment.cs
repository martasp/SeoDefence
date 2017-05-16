using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onScreenAchievment : MonoBehaviour {

    public Vector3 position;
    // Use this for initialization

    IEnumerator wait()
    {
        
        yield return new WaitForSeconds(3);
        this.transform.Translate(position * (-1));
    }

    public void showUp()
    {
        this.transform.Translate(position);
        StartCoroutine(wait());
        
    }
}
