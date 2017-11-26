using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraditionalIndicatorPoint : MonoBehaviour {

    public Enemy enemy;
    LineRenderer lr;
    public float totalAngle = 190f;
    public float angleOffset = 90f;
    public int segments = 32;
    public float radius = 1f;
    float enemyDirection;

    // Use this for initialization
    void Start ()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = segments;
        lr.useWorldSpace = false;
        enemyDirection = ((Mathf.Atan2(enemy.transform.position.x - transform.position.x, enemy.transform.position.z - transform.position.z) / Mathf.PI) * 180f) % 360;
        if (enemyDirection < 0)
        {
            enemyDirection += 360;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

        float rotationY = transform.eulerAngles.y % 360;
        if (rotationY < 0)
        {
            rotationY += 360;
        }

        float difference = enemyDirection - rotationY;

        float x = 0f;
        float y = 0f;
        float z = 0f;
        float angle = difference - angleOffset;

        for (int i = 0; i < (segments); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            lr.SetPosition(i, new Vector3(x, y, z));

            angle += (totalAngle / segments);
        }
    }
}
