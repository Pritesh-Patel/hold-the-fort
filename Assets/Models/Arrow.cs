using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D rigid;

	void Start () {

		rigid = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		Vector3 dir = rigid.velocity;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Health h = col.gameObject.GetComponent<Health> ();
		if (h != null)
			h.TakeDamage (1);
		Destroy (gameObject);
	}
}
