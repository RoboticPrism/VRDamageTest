using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Time;

public class Tracker : MonoBehaviour {
  string logs;
  float sessionTime;

	// Use this for initialization
	void Start() {
    sessionTime = 0;
	}

	// Update is called once per frame
	void Update() {
    sessionTime += Time.deltaTime;
	}

  void Track(string eventName) {
    int enemyNum;
    switch (eventName) {
      case 'SpawnEnemy':
        int enemyNum = newEnemy.number;
        logs += $"{eventName} || Enemy#: {enemyNum} | GameSessionTime: {sessionTime} | DegreeDifference: {degreeDifference}\n";
        break;
      case 'ViewEnemy':
        logs += $"{eventName} || Enemy#: {enemyNum} | GameSessionTime: {sessionTime}\n";
        break;
      case 'DestroyEnemy':
        int enemyNum =
        logs += $"{eventName} || Enemy#: {enemyNum} | GameSessionTime: {sessionTime}\n";
        break;
      default:
        break;
      }
  }

  /*
  void EnemySpawnTime() {
    int currentTime, enemyNum, enemySpawnTime, degreeDifference;
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
  }*/
}
