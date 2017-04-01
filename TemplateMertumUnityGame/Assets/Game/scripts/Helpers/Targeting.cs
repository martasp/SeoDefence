using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO Enemies should add and remove themselves from list

public class Targeting : MonoBehaviour {
    public List<Transform> targets = new List<Transform>();
    private Transform myTransform;
    public Transform selected = null;

	// Use this for initialization
	void Start () {
        myTransform = transform;

        AddAllEnemies();
	}

    void AddAllEnemies()
    {
        targets = new List<Transform>();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (var enemy in enemies)
        {
            targets.Add(enemy.transform);
        }
    }

    public void AddEnemy (Transform toAdd)
    {
        targets.Add(toAdd);
    }

    public void RemoveEnemy (Transform toRemove)
    {
        targets.Remove(toRemove);
    }

    private void SortTargets()
    {
        AddAllEnemies();
        targets.Sort(
            delegate(Transform t1, Transform t2)
            {
                return Vector3.Distance(t1.position, myTransform.position)
                .CompareTo(
                    Vector3.Distance(t2.position, myTransform.position));
            });
    }

    public Vector3 GetTarget()
    {
        if (targets.Count != 0)
        {
            SortTargets();
            selected = targets[0];
            return selected.position;
        }
        else return new Vector3(0, 0);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
