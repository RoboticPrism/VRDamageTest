using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using UnityEngine;

public class Tracker : MonoBehaviour {
  string logs;
  float sessionTime;
  string filePath;

    // Use this for initialization
    void Start() {
        sessionTime = 0;
        logs = "Event, Enemy#, SessionTime, DegreeDifference\r\n";
        filePath = Application.dataPath + "/" + "StatTrackerLogs.csv";
    }

	// Update is called once per frame
	void Update() {
    sessionTime += Time.deltaTime;
	}

    public void Export(Enemy enemy)
    {
        if (enemy.number == 30)
        {
            StreamWriter outStream = System.IO.File.CreateText(filePath);
            outStream.WriteLine(logs);
            outStream.Close();
        }
    }

  public void Track(string eventName, Enemy enemy) {
    int enemyNum = enemy.number;
    float degreeDifference = enemy.degreeDifference;
    switch (eventName) {
        case "SpawnEnemy":
            logs += eventName + ", " + enemyNum + ", " + sessionTime + ", " + degreeDifference + "\r\n";
            break;
        case "ViewEnemy":
            logs += eventName + ", " + enemyNum + ", " + sessionTime + "\r\n";
            break;
        case "DestroyEnemy":
            logs += eventName + ", " + enemyNum + ", " + sessionTime + "\r\n";
            break;
        default:
            logs += eventName + ", " + enemyNum + ", " + sessionTime + "\r\n";
            break;
    }
  }
}
