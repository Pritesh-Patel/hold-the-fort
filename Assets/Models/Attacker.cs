using System;
using UnityEngine;
using System.Collections;

public class Attacker : Spawnable
{
	[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
	[SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
	
	private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Animator m_Anim;            // Reference to the player's animator component.
	private Rigidbody2D m_Rigidbody2D;
	private int damageDone;
	
	private bool attacking = false;

	private float attackInterval = 2;
	private int damageAmount = 5;

	private void Awake()
	{
		// Setting up references.
		m_GroundCheck = transform.Find("GroundCheck");
		m_Anim = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update () {
		Health health = gameObject.GetComponent<Health>();
		if (health.currentHealth <= 0) {
			Debug.Log ("Attacker dead");
			//Add coins to GameController
			Destroy(gameObject);
		}
	}
		
	private void FixedUpdate()
	{
		m_Grounded = false;
		
		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				m_Grounded = true;
		}
		m_Anim.SetBool("Ground", m_Grounded);
		
		// Set the vertical animation
		m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
	}
	
	
	public void Move(float move)
	{
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		m_Anim.SetFloat("Speed", Mathf.Abs(move));
		// Move the character
		m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		switch (col.gameObject.tag)
		{
			case "Turret": StartCoroutine(HitTurret(col.gameObject)); break;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		switch (col.gameObject.tag)
		{
			case "Turret": this.attacking = false; break;
		}
	}
	
	#region implemented abstract members of Spawnable
	public override void Spawned ()
	{
		m_MaxSpeed = 3;
	}

	#endregion
	
	IEnumerator HitTurret(GameObject turret) {
		Debug.Log ("Hit turret");
		this.attacking = true;
		while(this.attacking) {
			if(!turret) break;
			Health health = turret.GetComponent<Health>();
			health.TakeDamage(damageAmount);
			yield return new WaitForSeconds(attackInterval);
		}
	}
}
