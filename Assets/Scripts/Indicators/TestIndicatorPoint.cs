using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIndicatorPoint : MonoBehaviour {

    public Enemy enemy;
    public Transform headCenter;
    LineRenderer lr;
    public int segments = 32;
    public float radius = 1f;
    float enemyDirection;

    void Start()
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

    void Update()
    {

        transform.position = new Vector3(headCenter.position.x, headCenter.position.y - 1f, headCenter.position.z);

        float rotationY = transform.eulerAngles.y % 360;
        if (rotationY < 0)
        {
            rotationY += 360;
        }

        float difference = enemyDirection - rotationY;

        if (difference > 180)
        {
            difference = difference - 360;
        } else if (difference < -180)
        {
            difference = difference + 360;
        }

        float x = 0f;
        float y = 0f;
        float z = 0f;
        float angle = 0f;

        for (int i = 0; i < (segments); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            lr.SetPosition(i, new Vector3(x, y, z));

            angle += (difference / segments);
        }
    }
}
