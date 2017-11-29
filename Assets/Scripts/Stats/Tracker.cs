using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour {
  // String logs = "";

	// Use this for initialization
	void Start () {
    // Initialization
	}

	// Update is called once per frame
	void Update () {
    // Per Frame Stuff
	}


  // Time from player getting hit to player having enemy in their field of view.
  returnType playerHitToEnemyInView() {
    // int statResult;
    // int timeOfPlayerHit, timeOfEnemyInView;
    // if(playerHit) {
    //   timeOfPlayerHit = System.Time();
    //   if(enemyInView) {
    //     timeOfEnemyInView = System.Time();
    //   }
    // }
    // statResult = timeOfEnemyInView - timeOfPlayerHit;
    // logs += "playerHitToEnemyInView: ";
    // logs += statResult;
    // logs += "\0";
  }

  // If player rotates past the enemy (and if they do, how far, and how many times).
  returnType rotatePastEnemy() {
    // int statResult;
    // float howFarPast = (playerInitialCamera-playerEndCamera)-(playerInitialCamera-enemyPosition);
    // float howManyTimes = ??? # of rotations or the total stat?
    // logs += "rotatePastEnemy: ";
    // logs += statResult;
    // logs += "\0";
  }

  // Time from having enemy in field of view to the player pulling the trigger.
  returnType enemyInViewToTriggerPull() {
    // int statResult;
    // int timeOfEnemyInView, timeOfTriggerPull;
    // if(enemyInView) {
    //   timeOfEnemyInView = System.Time();
    //   if(triggerPull) {
    //     timeOfTriggerPull = System.Time();
    //   }
    // }
    // statResult = timeOfTriggerPull - timeOfEnemyInView;
    // logs += "enemyInViewToTriggerPull: ";
    // logs += statResult;
    // logs += "\0";
  }

}
