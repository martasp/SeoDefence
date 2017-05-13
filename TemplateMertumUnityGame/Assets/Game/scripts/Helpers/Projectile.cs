using Assets.Game.scripts.Game;
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
    public SplashDamage selfDestruct;

    private Vector2 noTarget = new Vector2(0, 0);

    // Use this for initialization
    void Start () {
        targetSys = GetComponent<Targeting>();
        selfDestruct = GetComponent<SplashDamage>();
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
                transform.parent = null; //++ atskiria nuo teva kad nepaveldetu statisku kordinaciu kai tevas sukinejasi
                rotateProjectile(vec);//++ pasuka tinkama linkme raketa
                transform.position = Vector2.MoveTowards(transform.position, vec, missileVelocity * Time.deltaTime);
            }
            else selfDestruct.DealSplashDamage();
        }
    }
    private void rotateProjectile(Vector2 target)
    {
        //rotation
        Vector2 difference = target - (Vector2)this.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        var lerped = Mathf.LerpAngle(transform.rotation.eulerAngles.z, rotationZ, Time.deltaTime * rotSpeed);
        this.transform.eulerAngles = new Vector3(0, 0, lerped);
    }
}
