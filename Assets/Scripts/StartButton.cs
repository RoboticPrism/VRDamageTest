using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

    EnemySpawner spawner;

	// Use this for initialization
	void Start () {
        spawner = FindObjectOfType<EnemySpawner>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnShot()
    {
        spawner.start = true;
        gameObject.SetActive(false);
    }
}
