﻿using UnityEngine;
using System.Collections;

public class EnableGame : StateMachineBehaviour {
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameObject.Find ("Main Camera").GetComponent<IntroMain> ().readyToStart = true;
		GameObject.Find("titleFlowerCenter").GetComponent<Animator>().SetBool("gameStart", true);
		GameObject.Find("Title").GetComponent<Animator>().SetBool("gameStart", true);
		GameObject.Find("beginText").GetComponent<Animator>().SetBool("gameStart", true);
	}
	
//	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//		Debug.Log ("OnStateUpdate");
//	}
//	
//	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//		Debug.Log ("OnStateExit");
//	}
//	
//	override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//		Debug.Log ("OnStateMove");
//	}
//
//	override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
//		Debug.Log ("OnStateIK");
//	}
}
