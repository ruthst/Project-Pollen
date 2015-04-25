﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkList : MonoBehaviour {

	public GameObject WorkListPrefab;
	public int WORK_LIST_MAX;

	public Sprite[] sprites;

	public List<GameObject> listObjects;

	public Vector3[] positions;


	// Use this for initialization
	void Start () {
		listObjects = new List<GameObject>();
		newWorkList();
	}
	
	/*
	Check if pollen has been absorbed in order, and how many
	Filter down colors 
	generate new ones at the end
	*/

	// Update is called once per frame
	void Update () {
		removeOldWork();
		shiftWorkList();
		refillWorkList();
	}


	/*
	Generate new list of pollen to be achieved
	*/
	void newWorkList() {
		//get 5 random numbers mod 8, use those to get sprite

		for (int i = 0; i < WORK_LIST_MAX; i++) {

			int random = Random.Range(0,7);

			//Debug.Log("The random is " + random);
			listObjects.Add((GameObject) Instantiate(WorkListPrefab, positions[i], Quaternion.identity));
			listObjects[i].GetComponent<SpriteRenderer>().sprite = sprites[random];
		}

	}

	/*
	Remove the pollen that was successfully pulled into the node
	*/
	void removeOldWork(){
	}


	/*
	Shift worklist colors to the left
	*/
	void shiftWorkList() {

		int nextPollen = 0;
		bool shiftNeeded = false;

		for (int i = 0; i < WORK_LIST_MAX; i++) {
			if (listObjects[i] != null) {
				nextPollen = i;
				shiftNeeded = true;
				break;
			}
		}

		if (shiftNeeded) {
			foreach (GameObject elem in listObjects) {
				elem.transform.localPosition = new Vector3(positions[listObjects.IndexOf(elem) - nextPollen].x, positions[listObjects.IndexOf(elem) - nextPollen].y, positions[listObjects.IndexOf(elem) - nextPollen].z)
				;
			}
		}
	}


	/*
	Generate new workList colors in empty slots
	*/
	void refillWorkList() {
		for (int i = 0; i < WORK_LIST_MAX; i++) {
			if (listObjects[i] == null) {
				int random = Random.Range(0,7);

				listObjects.Add((GameObject) Instantiate(WorkListPrefab, positions[i], Quaternion.identity));
				listObjects[i].GetComponent<SpriteRenderer>().sprite = sprites[random];
			}

		}
	}

}