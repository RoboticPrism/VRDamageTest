using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public int maxEnemies = 3;
    public float secondsBetweenNextSpawn = 5f;
    public List<GameObject> instantiatedEnemies = new List<GameObject>();

    public float radius = 10;

    public GameObject enemyPrefab;

    Coroutine enemySpawnRoutine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (enemySpawnRoutine == null && instantiatedEnemies.Count < maxEnemies)
        {
            enemySpawnRoutine = StartCoroutine(SpawnEnemy());
        }
	}

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(secondsBetweenNextSpawn);

        int angleDeg = Random.Range(0, 360);
        float angleRad = Mathf.Deg2Rad * angleDeg;

        Vector3 spawnLocation = new Vector3(radius * Mathf.Sin(angleRad), 
                                            transform.position.y, 
                                            radius * Mathf.Cos(angleRad));
        Quaternion spawnRotation = Quaternion.AngleAxis(angleDeg + 180, Vector3.up);
        instantiatedEnemies.Add(Instantiate(enemyPrefab, spawnLocation, spawnRotation));

        enemySpawnRoutine = null;
    }
}
