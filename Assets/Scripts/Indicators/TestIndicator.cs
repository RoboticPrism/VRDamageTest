using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestIndicator : Indicator {

    public List<TestIndicatorPoint> indicatorPoints = new List<TestIndicatorPoint>();
    public TestIndicatorPoint indicatorPointPrefab;
    public Transform headCenter;

    void Start()
    {
        
    }

    void Update()
    {

    }


    public new void AddDamagePoint(Enemy enemy)
    {
        base.AddDamagePoint(enemy);
        TestIndicatorPoint newIndicator = Instantiate(indicatorPointPrefab, transform);
        newIndicator.enemy = enemy;
        newIndicator.headCenter = headCenter;
        indicatorPoints.Add(newIndicator);
    }

    public new void RemoveDamagePoint(Enemy enemy)
    {
        base.RemoveDamagePoint(enemy);
        TestIndicatorPoint removePoint = null;
        foreach (TestIndicatorPoint t in indicatorPoints)
        {
            if (t.enemy == enemy)
            {
                removePoint = t;
                break;
            }
        }
        indicatorPoints.Remove(removePoint);
        Destroy(removePoint.gameObject);
    }

}
