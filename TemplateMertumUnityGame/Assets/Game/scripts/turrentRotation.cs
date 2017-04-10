using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrentRotation : MonoBehaviour
{

    public int rotSpeed;
    public Vector2 vec;
    public bool IsRotating = false;

    private Vector2 noTarget = new Vector2(0, 0);
    public GameObject target;
    public Targeting targetSys;
    public Transform spawnPosition;

    void Start()
    {
        spawnPosition = GetComponentInParent<Transform>();
        spawnPosition.Rotate(transform.rotation.eulerAngles);
        targetSys = GetComponent<Targeting>();
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

    // Update is called once per frame
    void Update()
    {
        target = targetSys.GetTarget();
        if (target != null)
            vec = target.transform.position;
        else vec = noTarget;
        rotateGunAsinc(vec);
    }
}