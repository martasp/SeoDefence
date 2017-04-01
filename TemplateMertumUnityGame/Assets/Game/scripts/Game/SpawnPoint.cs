using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    public int enemiesCount=9;
    public float spawnInterval=1;
    public GameObject enemyType;
    //private Targeting targetSys;

    // Use this for initialization
    void Start () {
        StartCoroutine(Spawn());
        //targetSys = GetComponent<Targeting>();
    }

    IEnumerator Spawn()
    {
        Debug.Log(transform.position.x);
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
