﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public int Range;
    public int Damage;
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
    public List<Bullet> bullets;
    public GameObject rocketType;
    public GameObject rocketTypeLeft;
    public GameObject rocketTypeRight;
    public Transform spawnPosition;
    public bool start = false;
    public bool takeLeftProjectile = true;
    public AudioSource sound;

    public GameObject bload;
    public bool onTarget;

    public void Start()
    {
        if (start)
        {
            spawnPosition = GetComponentInParent<Transform>();
            sound = GetComponent<AudioSource>();
            spawnPosition.Rotate(transform.rotation.eulerAngles);
            targetSys = GetComponent<Targeting>();
            GetComponentsInChildren(true, projectiles);
            GetComponentsInChildren(true, bullets);
            StartCoroutine(SpawnFire());
            foreach (var rocket in projectiles)
            {
                rocket.GetComponent<PolygonCollider2D>().enabled = true;
            }
        }

    }

    private void rotateGunAsinc(Vector2 target)
    {
        //rotation
        float currAngle = transform.rotation.eulerAngles.z;
        Vector2 difference = target - (Vector2)transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        var lerped = Mathf.LerpAngle(currAngle, rotationZ, Time.deltaTime * rotSpeed);

        if (!isProjectileBased)
        {
            float targetAngle = Mathf.LerpAngle(currAngle, rotationZ, Mathf.Infinity);
            onTarget = (Mathf.Abs(currAngle - targetAngle) <= 20F && Vector2.Distance(transform.position, target) <= Range);
        }
   
        transform.eulerAngles = new Vector3(0, 0, lerped);
        IsRotating = true;
        
    }

    IEnumerator SpawnFire()
    {
        while (isProjectileBased)
        {
            if (projectiles.Count < numberOfWeapons)
            {
                if (numberOfWeapons == 2)
                {
                    rocketType = takeLeftProjectile ? rocketTypeLeft : rocketTypeRight;
                }
                GameObject rocket = Instantiate(rocketType, spawnPosition.position, transform.rotation * rocketType.transform.rotation);
                rocket.transform.Translate(rocketType.transform.position);
                rocket.transform.parent = transform;

                Projectile projectile = rocket.GetComponent<Projectile>();
                projectile.GetComponent<PolygonCollider2D>().enabled = true;
                projectile.isLeftProjectile = takeLeftProjectile;

                projectiles.Add(projectile);

                if (numberOfWeapons == 2)
                {
                    takeLeftProjectile = !takeLeftProjectile;
                }
                yield return new WaitForSeconds(fireRate);
            }
            else
            {
                if (target != null)
                {
                    foreach (var rocket in projectiles)
                    {
                        if (rocket.isLeftProjectile == takeLeftProjectile)
                        {
                            rocket.fired = true;
                            sound.Play();
                            projectiles.Remove(rocket);
                            break;
                        }
                    }
                }               
                yield return new WaitForSeconds(fireRate);
            }
                
        }
        while (!isProjectileBased)
        {
            if (target != null && onTarget)
            { 
                if (bullets.Count == 2)
                {
                    if (!bullets[0].fired)
                    {
                        if (!bullets[0].gameObject.activeSelf)
                        {
                            bullets[0].see();
                            sound.Play();
                            target.GetComponent<hp>().CurrentHP -= Damage;
                            Blood();
                            yield return new WaitForSeconds(0.1F);
                        }
                        else
                        {
                            bullets[0].hide();
                            bullets[0].fired = true;
                            bullets[1].fired = false;
                            yield return new WaitForSeconds(fireRate);
                        }
                        
                    }
                    else
                    {
                        if (!bullets[1].gameObject.activeSelf)
                        {
                            bullets[1].see();
                            sound.Play();
                            target.GetComponent<hp>().CurrentHP -= Damage;
                            Blood();
                            yield return new WaitForSeconds(0.1F);
                        }
                        else
                        {
                            bullets[1].hide();
                            bullets[1].fired = true;
                            bullets[0].fired = false;
                            yield return new WaitForSeconds(fireRate);
                        }
                    }
                }
                else
                {
                    if (!bullets[0].gameObject.activeSelf)
                    {
                        bullets[0].see();
                        sound.Play();
                        target.GetComponent<hp>().CurrentHP -= Damage;
                        Blood();
                        yield return new WaitForSeconds(0.1F);
                    }
                    else
                    {
                        bullets[0].hide();
                        yield return new WaitForSeconds(fireRate);
                    }
                    
                }

            }
            else
            {
                bullets[0].hide();
                if (bullets.Count == 2)
                {
                    bullets[1].hide();
                }
                yield return new WaitForSeconds(0.1F);
            }
            
        }
       
    }

    private void Blood()
    {
        var bload = Instantiate(this.bload, target.transform.position, new Quaternion());
        Destroy(bload, 5);
    }


    void Update ()
	{
	    if (start)
	    {
	        target = targetSys.GetTarget();
	        if (target != null)
	            vec = target.transform.position;
	        else vec = noTarget;
            rotateGunAsinc(vec);
        }
	}
}
