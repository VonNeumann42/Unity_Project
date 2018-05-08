using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
	public Transform warptarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Recall")) {
			//GetComponent<Animation>().Play("Recall");
			this.transform.position = warptarget.position;
		}
		
	}
}
