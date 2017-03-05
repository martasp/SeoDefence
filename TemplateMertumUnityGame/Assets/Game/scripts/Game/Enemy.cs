using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public bool IsMoving = false;
    public int  stopcount = 0;
    public float speed = 1;
    private List<Vector2> path;
    private Vector2 there;
    // Use this for initialization
    void Start () {
        path = GameObject.Find("path").GetComponent<Path>().Points;
       
    }
	
	// Update is called once per frame
	void Update () {
        if (!IsTHeEnd())
        {
            moveTo();
            IsWaypointFinished();
        }

    }
    public void moveTo()
    {
        //float step = speed * Time.deltaTime;
        there = path[stopcount];
        this.transform.position = Vector2.MoveTowards(this.transform.position, there, speed);
        Vector2 difference = there - (Vector2)this.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
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
