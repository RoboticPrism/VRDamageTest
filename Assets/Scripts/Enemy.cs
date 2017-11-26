using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public EnemySpawner spawner;
    public GameObject explosionPrefab;
   
    public AudioSource pewSource;

	// Use this for initialization
	void Start () {
        spawner = FindObjectOfType<EnemySpawner>();
        pewSource.PlayDelayed(.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnShot ()
    {
        spawner.RemoveEnemy(this);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
