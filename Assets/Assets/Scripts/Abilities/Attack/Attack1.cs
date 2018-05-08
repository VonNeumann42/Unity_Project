using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour {
	public int hitpoints = 10;
	public float totarget;
	public float range = 5.0f;

	void Update () {
		if (Input.GetButtonDown("Attack")) {

			RaycastHit hit ;
			if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
				totarget = hit.distance;
				if (totarget < range) {

					hit.transform.SendMessage("DeductPoints", hitpoints, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}