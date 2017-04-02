using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public int Range { get; set; }
    public int Damage { get; set; }
    public GameObject BulletORbomb { get; set; }
    public int rotSpeed;
    public Vector2 vec;
    public bool IsRotating = false;
    public bool isProjectileBased = false;
    public int numberOfWeapons = 1;
    public int fireRate = 2;

    private Vector2 noTarget = new Vector2(0, 0);
    public GameObject target;
    public Targeting targetSys;
    public List<Projectile> projectiles;
    public GameObject rocketType;
    public Transform spawnPosition;
    void Start()
    {
        spawnPosition = GetComponentInParent<Transform>();
        spawnPosition.Rotate(transform.rotation.eulerAngles);
        targetSys = GetComponent<Targeting>();
        GetComponentsInChildren(true, projectiles);
        StartCoroutine(SpawnFire());
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

    IEnumerator SpawnFire()
    {
        while (isProjectileBased)
        {
            if (projectiles.Count < numberOfWeapons)
            {
                GameObject rocket = Instantiate(rocketType, spawnPosition.position + rocketType.transform.position, transform.rotation * rocketType.transform.rotation);
                rocket.transform.parent = transform;
                projectiles.Add(rocket.GetComponent<Projectile>());
                yield return new WaitForSeconds(fireRate);
            }
            else
            {
                projectiles[0].fired = true;
                projectiles.RemoveAt(0);
                yield return new WaitForSeconds(fireRate);
            }
                
        }
    }

    // Update is called once per frame
    void Update ()
	{
        target = targetSys.GetTarget();
        if (target != null)
            vec = target.transform.position;
        else vec = noTarget;

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
