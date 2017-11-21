using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestIndicator : Indicator {

    List<TestIndicatorPoint> indicatorPoints = new List<TestIndicatorPoint>();
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
        List<TestIndicatorPoint> removeList = new List<TestIndicatorPoint>();
        indicatorPoints.RemoveAll(t => t.enemy == enemy);
    }

}
