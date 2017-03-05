using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
    
    public List<Enemy> Enemies = new List<Enemy>();
    public List<Vector2> Points = new List<Vector2>();
    void Start () {
       // move();
    }
	
	void Update () {
    }
    public void move()
    {
        foreach (var enemy in Enemies)
        {
            enemy.StartMoveing();
        } 
    }
}


//public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta);