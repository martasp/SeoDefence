using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO Enemies should add and remove themselves from list

public class Targeting : MonoBehaviour {
    public List<GameObject> targets = new List<GameObject>();
    private Transform myTransform;
    public GameObject selected = null;

	// Use this for initialization
	void Start () {
        myTransform = transform;

        AddAllEnemies();
	}

    void AddAllEnemies()
    {
        targets = new List<GameObject>();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (var enemy in enemies)
        {
            targets.Add(enemy);
        }
    }

    public void AddEnemy (GameObject toAdd)
    {
        targets.Add(toAdd);
    }

    public void RemoveEnemy (GameObject toRemove)
    {
        targets.Remove(toRemove);
    }

    private void SortTargets()
    {
        AddAllEnemies();
        targets.Sort(
            delegate(GameObject t1, GameObject t2)
            {
                return Vector3.Distance(t1.transform.position, myTransform.position)
                .CompareTo(
                    Vector3.Distance(t2.transform.position, myTransform.position));
            });
    }

    public GameObject GetTarget()
    {
        if (targets.Count != 0)
        {
            SortTargets();
            selected = targets[0];
            return selected;
        }
        else return null;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
