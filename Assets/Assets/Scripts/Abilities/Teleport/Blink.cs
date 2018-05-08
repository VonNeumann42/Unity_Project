using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
	public Transform warptarget;
	public Transform drop;
	public Transform me;
	public Vector3 vec = Vector3.zero;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Blink")) {
			warptarget.transform.position = Vector3.zero;
			RaycastHit hit;
			if (Physics.Raycast (this.transform.position, transform.TransformDirection (Vector3.forward), out hit)) {
				Vector3 incomingVec = hit.point - this.transform.position;
				if (incomingVec.magnitude < 30) {
					Vector3 reflectVec = Vector3.Reflect (incomingVec, hit.normal);
					warptarget.transform.position = hit.point + (reflectVec).normalized;
				} else {
					vec = transform.TransformDirection (Vector3.forward).normalized;
					vec = vec * 30;
					vec = vec + me.position;
					warptarget.transform.position = vec;
				}


			} else {
				vec = transform.TransformDirection (Vector3.forward).normalized;
				vec = vec * 30;
				vec = vec + me.position;
				warptarget.transform.position = vec;

			}
			Physics.Raycast (warptarget.position, Vector3.down, out hit);
			drop.transform.position = hit.point;
		}
		if (Input.GetButtonUp("Blink")) {
			me.position = warptarget.position;
			warptarget.transform.position = Vector3.down;
			drop.transform.position = Vector3.down;
		}
			
		
	}
}
