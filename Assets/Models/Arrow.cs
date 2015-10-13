using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D rigid;

	void Start () {

		rigid = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.right =
			Vector3.Slerp(this.transform.right, rigid.velocity.normalized, Time.deltaTime);
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Health h = col.gameObject.GetComponent<Health> ();
		if (h != null)
			h.TakeDamage (1);
		Destroy (gameObject);
	}
}
