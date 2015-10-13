using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	// Use this for initialization
	public GameObject projectile;
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Fire(Quaternion angle)
	{
		GameObject go = Instantiate(projectile,this.transform.position,angle) as GameObject;
		go.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (380, 0));
		       
	}
}
