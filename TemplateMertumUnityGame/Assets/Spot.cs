using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class Spot : MonoBehaviour
{
    public GameObject tower; // need tower 
    public void SetTower(GameObject tower)
    {
        this.tower = tower;
        tower.transform.position = this.transform.position;

    }

    public void DeleteTower()
    {
        Destroy(tower);
        //var towerValue = (int)(25 / 2);
        //PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + towerValue);
    }
}
