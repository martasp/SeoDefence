using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour {

    public int Range { get; set; }
    public int Damage { get; set; }
    public GameObject BulletORbomb { get; set; }
    public int rotSpeed;
    public Vector2 vec;
    public bool IsRotating = false;

    private Transform target;
    public Targeting targetSys;
    void Start()
    {
        targetSys = GetComponent<Targeting>();
        //this.transform.localEulerAngles.z += 90;
        //target = GetComponent<TargetSystem>()
    }
    public void fire()
    {
      //  var Enemy = target.getEnemy();
    }

    private void rotateGunAsinc(Vector2 target)
    {
        //rotation
        Vector2 difference = target - (Vector2)this.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        var lerped = Mathf.LerpAngle(transform.rotation.eulerAngles.z, rotationZ, Time.deltaTime * rotSpeed);
        this.transform.eulerAngles = new Vector3(0, 0, lerped);
        IsRotating = true;
        //if ( Mathf.abs(target.z - lerped)< 0.3f )
        //{
        //    IsRotating = false;
        //}
    }
	
	// Update is called once per frame
	void Update ()
	{
        vec = targetSys.GetTarget();
	    rotateGunAsinc(vec);
	    //rotate(vec);
	    //Instantiate<GameObject>(BulletORbomb);
	    //  rotate(new Vector2(-5, 3));
	}

    //public void rotate(Vector2 v)
    //{

    //    if (!IsRotating)
    //    {
    //        IsRotating = true;
    //        rotateGunAsinc(v);
    //    }
    //    if (IsRotating)
    //    {
    //        rotateGunAsinc(v);

    //    }else if(rotateGunAsinc(v) < 0.00005f)
    //    {
    //        IsRotating = false; // nebesisuka
    //    }
    //}


}
