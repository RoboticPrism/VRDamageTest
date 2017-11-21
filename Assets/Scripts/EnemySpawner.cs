using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public TestIndicator indicator;

    public int maxEnemies = 3;
    public float secondsBetweenNextSpawn = 5f;
    public List<Enemy> instantiatedEnemies = new List<Enemy>();

    public float radius = 10;

    public Enemy enemyPrefab;

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
        Enemy newEnemy = Instantiate(enemyPrefab, spawnLocation, spawnRotation);
        AddEnemy(newEnemy);
        enemySpawnRoutine = null;
    }

    public void AddEnemy(Enemy enemy)
    {
        instantiatedEnemies.Add(enemy);
        indicator.AddDamagePoint(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        instantiatedEnemies.RemoveAll(e => e == enemy);
        indicator.RemoveDamagePoint(enemy);
    }
}
