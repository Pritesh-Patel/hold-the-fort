using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public bool finalTurret;

	// Use this for initialization
	void Start () {

	}
	
	void Update () {
		Health health = gameObject.GetComponent<Health>();
		if (health.currentHealth <= 0) {
			Debug.Log ("Turret dead");
			if(this.finalTurret) {
				Debug.Log("GAME OVER!");
			}
			Destroy(gameObject);
		}
	}
}
