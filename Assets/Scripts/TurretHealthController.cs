using UnityEngine;
using System.Collections;

public class TurretHealthController : MonoBehaviour {

	public float max_Health = 100f;
	public GameObject healthBar;

	// Use this for initialization
	void Start () {
		max_Health = gameObject.GetComponentInParent<Health> ().maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		decreaseHealth();
	}

	void decreaseHealth() {
		float current_Health = gameObject.GetComponentInParent<Health> ().currentHealth;
		float calculate_Health = current_Health / max_Health;
		healthBar.transform.localScale = new Vector3 (calculate_Health, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
