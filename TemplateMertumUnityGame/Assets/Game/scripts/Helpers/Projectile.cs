using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float missileVelocity = 200;
    public Targeting targetSys;
    public GameObject target;
    public Vector2 vec;
    public const int rotSpeed = 20;
    public bool fired = false;

    private Vector2 noTarget = new Vector2(0, 0);

    // Use this for initialization
    void Start () {
        targetSys = GetComponent<Targeting>();
        vec = noTarget;
    }
	
	// Update is called once per frame
	void Update () {
        if (fired)
        {
            target = targetSys.GetTarget();
            if (target != null)
            {
                vec = target.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, vec, missileVelocity * Time.deltaTime);
            }
            else vec = noTarget;
        }
    }
}
