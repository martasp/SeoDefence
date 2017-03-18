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
}
