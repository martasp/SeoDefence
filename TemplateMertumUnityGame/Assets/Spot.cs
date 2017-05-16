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
            GameObject.Find("GameManager").GetComponent<AchievmentManager>().addTower(); //add builded towers count in achievments
            if (GameObject.Find("GameManager").GetComponent<AchievmentManager>().checkBuildedTowers())
                GameObject.Find("builder").GetComponent<onScreenAchievment>().showUp();
            GameObject.Find("GameManager").GetComponent<AchievmentManager>().addMoneySpent(towerIn.GetComponent<Info>().price);
            if (GameObject.Find("GameManager").GetComponent<AchievmentManager>().checkMoneySpent())
                GameObject.Find("lordOfWar").GetComponent<onScreenAchievment>().showUp();
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
        GameObject.Find("GameManager").GetComponent<AchievmentManager>().addSoldTowers();
        if (GameObject.Find("GameManager").GetComponent<AchievmentManager>().checkSoldTowers())
            GameObject.Find("estateAgent").GetComponent<onScreenAchievment>().showUp();
        GameObject.Find("GameManager").GetComponent<AchievmentManager>().addMoneyEarned(towerValue);
        if (GameObject.Find("GameManager").GetComponent<AchievmentManager>().checkMoneyEarned())
            GameObject.Find("monopolist").GetComponent<onScreenAchievment>().showUp();
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

