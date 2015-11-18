using UnityEngine;
using System.Collections;

public class TurretHealthController : MonoBehaviour {

	public float max_Health = 100f;
	public float current_Health = 0f;
	public GameObject healthBar;

	// Use this for initialization
	void Start () {
		current_Health = max_Health;
		InvokeRepeating ("decreaseHealth", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void decreaseHealth() {
		current_Health -= 2f;
		float calculate_Health = current_Health / max_Health;
		setHealthBar (calculate_Health);
	}

	public void setHealthBar(float myHealth) {
		healthBar.transform.localScale = new Vector3 (myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
