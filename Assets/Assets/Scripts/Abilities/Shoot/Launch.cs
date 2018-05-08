using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {

	int launched = 0;
	int count = 0;
	public Vector3 target = Vector3.zero;
	public Transform projectile;
	public Transform character;


	void Update () {
		if(Input.GetButtonDown("Attack")){
			if (launched == 0 && count == 0) {
				projectile.parent = null;
				launched = 1;
				RaycastHit hit;
				if (Physics.Raycast (this.transform.position, transform.TransformDirection (Vector3.forward), out hit)) {
					target = hit.point - this.transform.position;
					if (target.magnitude < 30) {
						int difference = (int)(4 * target.magnitude);
						count = 120 - difference;
					}
				} else {
					target = transform.TransformDirection (Vector3.forward);
				}
				target = target.normalized;
				target = target / 4;
			}
		}

		if(launched == 1){
			count++;
			projectile.transform.position = projectile.position + target;
		}
		if (count == 120 && launched == 1) {
			launched = 2;
		}
		if(launched == 2 && count % 10 == 0){
			target = character.position - projectile.position;
			if (target.magnitude < 2) {
				projectile.transform.parent = character.transform;

				launched = 0;
				count = 120;

			}
			target = target.normalized;
			target = target / 4;
		}
		if (launched == 2) {
			projectile.transform.position = projectile.position + target;
		}
		if(launched == 0 && count > 0){
			count--;
			projectile.transform.position = Vector3.zero;
		}
	}
}
