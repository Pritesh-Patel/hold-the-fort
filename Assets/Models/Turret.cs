using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public bool finalTurret;

	public Defender turretDefender;

	// Use this for initialization
	void Start () 
	{

	}
	
	void Update () 
	{
		Health health = gameObject.GetComponent<Health>();
		if (health.currentHealth <= 0) {
			Debug.Log ("Turret dead");
			if(this.finalTurret) {
				Debug.Log("GAME OVER!");
			}
			Destroy(this.turretDefender.gameObject);
			Destroy(this.gameObject);
		}
	}

	Defender getTurretDefender()
	{
		return this.turretDefender;
	}

	void setTurretDefender(Defender def)
	{
		this.turretDefender = def;
	}
}
