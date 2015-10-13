using System;
using UnityEngine;

public class Attacker : Spawnable
{
	[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
	[SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
	
	private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Animator m_Anim;            // Reference to the player's animator component.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private int damageDone;

	private void Awake()
	{
		// Setting up references.
		m_GroundCheck = transform.Find("GroundCheck");
		m_Anim = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
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
		// If the input is moving the player right and the player is facing left...
		if (move > 0 && !m_FacingRight) Flip();
	}
	
	
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	
	//Custom code
	
	void OnCollisionEnter2D(Collision2D col)
	{
		switch (col.gameObject.tag)
		{
		case "Turret": HitTurret(col); break;
		}
	}
	
	#region implemented abstract members of Spawnable
	public override void Spawned ()
	{
		m_MaxSpeed = 3;
		
	}
	#endregion
	
	private void HitTurret(Collision2D other) {
		Health turret = other.gameObject.GetComponent<Health>();
		if (turret.currentHealth <= 0) {
			Debug.Log ("Dead");
		} else {
			turret.TakeDamage (5);
		}
	}

}