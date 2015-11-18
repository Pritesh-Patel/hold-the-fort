using System;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	public Health health;     
	public float restartDelay = 5f;         
		
	Animator anim;                          
	float restartTimer;                     

	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
	}
	
	
	void Update ()
	{
		if(health.currentHealth <= 0)
		{
			anim.SetTrigger ("GameOver");
			
			restartTimer += Time.deltaTime;
			
			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}