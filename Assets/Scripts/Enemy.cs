using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int number;
    public bool seen;
    public float degreeDifference;

    public EnemySpawner spawner;
    public GameObject explosionPrefab;

    public AudioSource pewSource;
    public Tracker tracker;

    public Transform headTransform;

	// Use this for initialization
	void Start () {
        seen = false;
        spawner = FindObjectOfType<EnemySpawner>();
        pewSource.PlayDelayed(.5f);
        degreeDifference = DegreeDifference();

        tracker.Track("SpawnEnemy", this);
    }

	// Update is called once per frame
	void Update () {
        float difference = DegreeDifference();

        if (Mathf.Abs(difference) < 45 && !seen)
        {
            seen = true;
            tracker.Track("ViewEnemy", this);
        }
    }

    public void OnShot ()
    {
        // log destroyed
        spawner.RemoveEnemy(this);
        tracker.Track("DestroyEnemy", this);
        tracker.Export(this);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }

    public float DegreeDifference() 
    {
        float enemyDirection = ((Mathf.Atan2(transform.position.x - headTransform.position.x, transform.position.z - headTransform.position.z) / Mathf.PI) * 180f) % 360;
        float rotationY = headTransform.eulerAngles.y % 360;
        if (rotationY < 0)
        {
            rotationY += 360;
        }
        return (enemyDirection - rotationY) % 180;
    }
}
