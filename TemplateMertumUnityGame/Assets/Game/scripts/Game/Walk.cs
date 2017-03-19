using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

    public bool IsMoving = false;
    public int  stopcount = 0;
    public float speed = 1;
    public float rotSpeed = 10;
    private List<Vector2> path;
    private Vector2 there;
    private HealthBar MyHp;
    // Use this for initialization
    void Start ()
    {
        MyHp = GameObject.Find("Slider").GetComponent<HealthBar>();
        path = GameObject.Find("path").GetComponent<Path>().Points;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (!IsTHeEnd())
        {
            moveTo();
            IsWaypointFinished();
        }
        else
        {
           die();
        }

    }

    public void die()
    {
        MyHp.Damage();
        Destroy(this.gameObject);
    }
    public void moveTo()
    {
        there = path[stopcount];
        //moveing
        this.transform.position = Vector2.MoveTowards(this.transform.position, there, speed * Time.deltaTime);
        Vector2 difference = there - (Vector2)this.transform.position;
       

        //rotation
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg ;
        var lerped = Mathf.LerpAngle(transform.rotation.eulerAngles.z, rotationZ, Time.deltaTime * rotSpeed);
        this.transform.eulerAngles= new Vector3(0,0,lerped);
        Debug.Log("moving to point");      
    }
    public bool IsWaypointFinished()
    {
        var there = path[stopcount];
        if (Vector2.Distance(this.transform.position,there) < 0.3f)
        {
            Debug.Log("i em here in the point" + stopcount);
            stopcount++;
            //StopMoveing(); 
            return true;
        }
        return false;
    }
    public void StopMoveing()
    {
        IsMoving = false;
    }
    public void StartMoveing()
    {
        IsMoving = true;
    }
    public IEnumerator Go()
    {
        while (!IsMoving)
        {
           // moveTo();
            yield return new WaitForSeconds(.1f);
        }
    }
    public bool IsTHeEnd()
    {
        return stopcount == path.Count;
    }
}
