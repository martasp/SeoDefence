using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    public int enemiesCount=3;
    public float spawnInterval=1;
    public GameObject enemyType;

    // Use this for initialization
    void Start () {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        Debug.Log(transform.position.x);
        for (int i = 0; i < enemiesCount; i++)
        {
            Instantiate(enemyType, new Vector3(transform.position.x - i, transform.position.y), Quaternion.identity).SetActive(true);
            yield return new WaitForSecondsRealtime(spawnInterval);
        }
    }
		// Update is called once per frame
	void Update () {
		
	}
}
