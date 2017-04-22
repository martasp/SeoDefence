using UnityEngine;

public class Spot : MonoBehaviour
{
    public GameObject tower=null; // need tower 
    public bool IsOn = false;
    public void SetTower(GameObject towerIn)
    {
        var isBuyOK = GameObject.Find("Money").GetComponent<MoneyScript>().Sub(towerIn.GetComponent<Info>().price);
        if (!IsOn && isBuyOK)
        {
            Debug.Log("snapina");
            this.tower = towerIn;
            this.tower.transform.position = this.transform.position;
            IsOn = true;
            towerIn.transform.Find("Tower (1)").GetComponent<Tower>().start = true;
            towerIn.transform.Find("Tower (1)").GetComponent<Tower>().Start();
        }
        else
        {
            tower = null;
            Destroy(towerIn);
        }
    }

    public void DeleteTower()
    {
        IsOn = false;
        var towerValue = (int)(tower.GetComponent<Info>().price / 2);
        GameObject.Find("Money").GetComponent<MoneyScript>().Add(towerValue);
        Destroy(tower);

    }
    public void OnMouseDown()
    {
        if (IsOn)
        {
            Debug.Log("veikia spot click");
            DeleteTower(); 
        }

    }

    public void OnMouseOver()
    {
        if (IsOn)
        {
            var sell = GameObject.Find("sell").GetComponent<SpriteRenderer>();
            sell.enabled = true;
        }
    }
    public void OnMouseExit()
    {
            var sell = GameObject.Find("sell").GetComponent<SpriteRenderer>();
            sell.enabled = false;
          //  var Temp = tower.GetComponent<SpriteRenderer>().color;
            //  tower.GetComponent<SpriteRenderer>().color=
    }
}

