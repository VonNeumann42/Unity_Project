using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int enemyhealth = 50;

	void DeductPoints(int hitpoints){
		enemyhealth -= hitpoints;
		if (enemyhealth <= 0) {
			Destroy (gameObject);
		}
	}


}