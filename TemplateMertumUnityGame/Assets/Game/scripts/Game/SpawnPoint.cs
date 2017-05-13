using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    public int enemiesCount=9;
    public float spawnInterval=1;
    public GameObject enemyType;
    public int StartSpawningAfterSeconds = 0;


    //private Targeting targetSys;

    // Use this for initialization
    void Start () {
        Invoke("StartSpawn", StartSpawningAfterSeconds);
    }

    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < enemiesCount; i++)
        {
            GameObject spawnling = Instantiate(enemyType, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            spawnling.SetActive(true);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
		// Update is called once per frame
	void Update () {
		
	}
}
