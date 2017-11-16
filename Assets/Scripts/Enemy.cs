﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    public EnemySpawner spawner;
    public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
        spawner = FindObjectOfType<EnemySpawner>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnShot ()
    {
        spawner.instantiatedEnemies.Remove(this.gameObject);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
