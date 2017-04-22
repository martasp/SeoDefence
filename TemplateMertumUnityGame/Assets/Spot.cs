using UnityEngine;

public class Spot : MonoBehaviour
{
    public GameObject tower=null; // need tower 
    public bool IsOn = false;
    public void SetTower(GameObject towerIn)
    {
        if (!IsOn)
        {
            this.tower = towerIn;
            this.tower.transform.position = this.transform.position;
            IsOn = true;
        }
        else
        {
            Destroy(towerIn);
        }



    }

    public void DeleteTower()
    {
        Destroy(tower);
        IsOn = false;
        //var towerValue = (int)(25 / 2);
        //PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + towerValue);
    }
}
