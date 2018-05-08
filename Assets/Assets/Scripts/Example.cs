using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {
	public Transform gunObj;
	void Update() {
		if (Input.GetButtonDown("Attack")) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				Vector3 incomingVec = hit.point - gunObj.position;
				Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);
				Debug.DrawLine(gunObj.position, hit.point, Color.red);
				Debug.DrawRay(hit.point, reflectVec, Color.green);
			}
		}
	}
}