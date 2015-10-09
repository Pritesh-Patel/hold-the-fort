using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void TakeDamage(int dmg)
	{
		currentHealth -= dmg;
	}
	
	public void AddHealth(int health)
	{
		currentHealth += health;
		if (currentHealth > maxHealth) 
		{
			currentHealth = maxHealth;
		}
		
	}
}
