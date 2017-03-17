using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour {

	// Use this for initialization\
    public int maxHP;
    public int CurrentHP;
    private SpriteRenderer img;

	void Start ()
	{
	    img = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (CurrentHP<1)
	    {
	        var alpha = img.color.a;
            var delta = img.color.a * Time.deltaTime*10;
	        img.color = new Color(1f,1f,1f,alpha-delta);
	    }
	    if (img.color.a<0.01f)
	    {
	        Destroy(this.gameObject);
	    }
	}
}
