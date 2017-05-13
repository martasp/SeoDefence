using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector3 dist;
    float posX;
    float posY;
    public GameObject obj;
    private GameObject tempreal;

    public void click()
    {
        Debug.Log("begin");
        tempreal = Instantiate(obj);
    }
    public void tempia()
    {
        var temp = obj.transform.position.z;
        Vector3 curPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y, -10);
        Debug.Log("drag");
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);

        tempreal.transform.position = new Vector3(worldPos.x, worldPos.y, temp);
    }
    public void end()
    {
        Vector3 curPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        var spots = GameObject.FindGameObjectsWithTag("spot");
        foreach (var spot in spots)
        {
            if (!spot.GetComponent<Spot>().IsOn)
            {
                worldPos.Set(worldPos.x, worldPos.y, 0);
               // spot.GetComponent<BoxCollider2D>().bounds.Expand(new Vector3(10,10,10));
                var isThere = spot.GetComponent<BoxCollider2D>().bounds.Contains(worldPos);
                Debug.Log(spot.GetComponent<BoxCollider2D>().bounds);
                Debug.Log(worldPos);
                Debug.Log(isThere);
                if (isThere && tempreal!=null)
                {
                    spot.GetComponent<Spot>().SetTower(tempreal);
                    return;
                }
            }
        }
        Destroy(tempreal);
    }
}
