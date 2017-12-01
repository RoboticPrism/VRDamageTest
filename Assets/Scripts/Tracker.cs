using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour {
  string logs;
  float sessionTime;

	// Use this for initialization
	void Start() {
        sessionTime = 0;
        logs = "Event, Enemy#, SessionTime, DegreeDifference\n";
	}

	// Update is called once per frame
	void Update() {
    sessionTime += Time.deltaTime;
	}

    public void printer()
    {
        Debug.Log(logs);
    }

  public void Track(string eventName, Enemy enemy) {
    int enemyNum = enemy.number;
    int degreeDifference = 0;
    switch (eventName) {
          case "SpawnEnemy":
            logs += eventName + ", " + enemyNum + ", " + sessionTime + ", " + degreeDifference + "\n";
            break;
        case "ViewEnemy":
            logs += eventName + ", " + enemyNum + ", " + sessionTime + "\n";
            break;
        case "DestroyEnemy":
            logs += eventName + ", " + enemyNum + ", " + sessionTime + "\n";
            break;
        default:
            logs += eventName + ", " + enemyNum + ", " + sessionTime + "\n";
            break;
    }
  }
}
