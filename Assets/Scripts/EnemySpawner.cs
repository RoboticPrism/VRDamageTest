using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    bool start = false;
    public enum indicatorType { TRADITIONAL, TEST }
    public indicatorType currentIndicator = indicatorType.TRADITIONAL;

    public TestIndicator testIndicator;
    public TraditionalIndicator tradIndicator;

    int maxEnemies = 1;
    float secondsBetweenNextSpawn = 5f;
    List<Enemy> instantiatedEnemies = new List<Enemy>();

    public float radius = 10;

    public Enemy enemyPrefab;
    int enemiesDestroyed = 0;
    Coroutine enemySpawnRoutine;

	// Use this for initialization
	void Start () {
		if(currentIndicator == indicatorType.TEST)
        {
            tradIndicator.gameObject.SetActive(false);
        } else
        {
            testIndicator.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (start)
        {
            if (enemySpawnRoutine == null && instantiatedEnemies.Count < maxEnemies && enemiesDestroyed < 30)
            {
                enemySpawnRoutine = StartCoroutine(SpawnEnemy());
            }
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

    public void StartGame()
    {
        start = true;
    }

    public void AddEnemy(Enemy enemy)
    {
        instantiatedEnemies.Add(enemy);
        testIndicator.AddDamagePoint(enemy);
        tradIndicator.AddDamagePoint(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        instantiatedEnemies.RemoveAll(e => e == enemy);
        testIndicator.RemoveDamagePoint(enemy);
        tradIndicator.RemoveDamagePoint(enemy);
        Destroy(enemy.gameObject);
        enemiesDestroyed += 1;
        if (enemiesDestroyed > 5)
        {
            maxEnemies = 2;
            secondsBetweenNextSpawn = 3f;
        }
        if (enemiesDestroyed > 10)
        {
            maxEnemies = 3;
            secondsBetweenNextSpawn = 2f;
        }
    }
}
