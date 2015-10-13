using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	public void TakeDamage(int dmg)
	{
		if(currentHealth - dmg < 0) currentHealth = 0;
		else currentHealth -= dmg;
	}
	
	public void AddHealth(int health)
	{
		if (currentHealth > maxHealth) currentHealth = maxHealth;
		else currentHealth += health;
	}
}
