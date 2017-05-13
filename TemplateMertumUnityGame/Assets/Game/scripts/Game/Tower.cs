using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public int Range { get; set; }
    public int Damage;
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
    public List<Bullet> bullets;
    public GameObject rocketType;
    public Transform spawnPosition;
    public bool start = false;
    public void Start()
    {
        if (start)
        {
            spawnPosition = GetComponentInParent<Transform>();
            spawnPosition.Rotate(transform.rotation.eulerAngles);
            targetSys = GetComponent<Targeting>();
            GetComponentsInChildren(true, projectiles);
            GetComponentsInChildren(true, bullets);
            StartCoroutine(SpawnFire());
        }

    }

    private void rotateGunAsinc(Vector2 target)
    {
        //rotation
        Vector2 difference = target - (Vector2)this.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        var lerped = Mathf.LerpAngle(transform.rotation.eulerAngles.z, rotationZ, Time.deltaTime * rotSpeed);
        this.transform.eulerAngles = new Vector3(0, 0, lerped);
        IsRotating = true;
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
                if (target != null)
                {
                    projectiles[0].fired = true;
                    projectiles.RemoveAt(0);
                }               
                yield return new WaitForSeconds(fireRate);
            }
                
        }
        while (!isProjectileBased)
        {
            if (target != null)
            { 
                if (bullets.Count == 2)
                {
                    if (!bullets[0].fired)
                    {
                        if (!bullets[0].gameObject.activeSelf)
                        {
                            bullets[0].see();
                            target.GetComponent<hp>().CurrentHP -= Damage;
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
                            target.GetComponent<hp>().CurrentHP -= Damage;
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
                        target.GetComponent<hp>().CurrentHP -= Damage;
                        yield return new WaitForSeconds(0.1F);
                        //StartCoroutine(bullets[0].Flash());
                        //bullets[0].GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else
                    {
                        bullets[0].hide();
                        yield return new WaitForSeconds(fireRate);
                    }
                    
                    //StartCoroutine(bullets[0].Flash());
                }
                //target.GetComponent<hp>().CurrentHP -= Damage;

            }
            yield return new WaitForSeconds(0.1F);
        }
       
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
