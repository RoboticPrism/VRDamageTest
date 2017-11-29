using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tracker : MonoBehaviour {
  string logs;
  long elapsedTicks;
  DateTime centuryBegin, sessionStart;

  centuryBegin = new DateTime(2001, 1, 1);

	// Use this for initialization
	void Start () {
    sessionStart = DateTime.Now;
    elapsedTicks = sessionStart.Ticks - centuryBegin.Ticks;
	}

	// Update is called once per frame
	void Update () {
  // TODO
	}

  // Time of enemy spawn
  void EnemySpawnTime() {
    int currentTime, enemyNum, enemySpawnTime, degreeDifference;
    currentTime = DateTime.Now;
    enemySpawnTime = currentTime.Ticks - elapsedTicks;
    // enemyNum = this.enemyNum; TODO
    // degreeDifference = TODO

    string result = $"EnemySpawnTime || Enemy#: {enemyNum} | GameSessionTime: {enemySpawnTime} | DegreeDifference: {degreeDifference}\n";
    logs += result;
  }

  // Time of enemy entering player's view
  void EnemyInViewTime() {
    int currentTime, enemyNum, enemyInViewTime;
    currentTime = DateTime.Now;
    enemyInViewTime = currentTime.Ticks - elapsedTicks;
    // enemyNum = appearedEnemy.enemyNum; TODO

    string result = $"EnemyInViewTime || Enemy#: {enemyNum} | GameSessionTime: {enemyInViewTime}\n";
    logs += result;
  }

  // Time of enemy being shot
  void EnemyIsShotTime() {
    int currentTime, enemyNum, enemyIsShotTime;
    currentTime = DateTime.Now;
    enemyIsShotTime = currentTime.Ticks - elapsedTicks;
    // enemyNum = this.enemyNum; TODO

    string result = $"EnemyIsShotTime || Enemy#: {enemyNum} | GameSessionTime: {enemyIsShotTime}\n";
    logs += result;
  }
}
