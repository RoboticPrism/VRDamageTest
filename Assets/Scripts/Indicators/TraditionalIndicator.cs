using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraditionalIndicator : Indicator {

    public List<TraditionalIndicatorPoint> indicatorPoints = new List<TraditionalIndicatorPoint>();
    public TraditionalIndicatorPoint indicatorPointPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public new void AddDamagePoint(Enemy enemy)
    {
        base.AddDamagePoint(enemy);
        TraditionalIndicatorPoint newIndicator = Instantiate(indicatorPointPrefab, transform);
        newIndicator.enemy = enemy;
        indicatorPoints.Add(newIndicator);
    }

    public new void RemoveDamagePoint(Enemy enemy)
    {
        base.RemoveDamagePoint(enemy);
        TraditionalIndicatorPoint removePoint = null;
        foreach (TraditionalIndicatorPoint t in indicatorPoints)
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
