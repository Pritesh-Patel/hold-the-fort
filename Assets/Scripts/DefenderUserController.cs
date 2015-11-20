using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefenderUserController : MonoBehaviour {

	// Use this for initialization
	public float 			maxTopAngle;
	public float 			minBotAngle;
	public float 			projectileDistance;
	public bool 			showDebugAngles;
	public bool 			showDebugAim;
	public bool 			aiming = true;
	private Quaternion 		upper;
	private Quaternion 		lower;

	void Start () {
		upper = Quaternion.Euler (0, 0, maxTopAngle);
		lower = Quaternion.Euler (0, 0, minBotAngle);
	}

	// Update is called once per frame
	void Update ()
	{
		if (aiming) {
			AimAtMouse();
		}

		if (Input.GetMouseButtonDown (0)) {
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("Defender"))
			{
				go.GetComponent<Defender>().Fire(go.transform.rotation);
			}
		}
	}

	public void AimAtMouse()
	{
		GameObject[] defenders = GameObject.FindGameObjectsWithTag("Defender");
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		foreach (GameObject def in defenders) {

			float radians = Mathf.Atan2(mousePos.y,mousePos.x);
			float degrees = radians * (180/Mathf.PI);

			//if (Quaternion.Euler(0,0,degrees)< upper) degrees = maxTopAngle;
			//if (degrees < minBotAngle) degrees = minBotAngle;
			def.transform.rotation = Quaternion.Euler(0, 0, degrees);
			if (showDebugAim)
			{
				Debug.DrawRay(def.transform.position, def.transform.right,Color.green);
			}
		}
	}

	public void ShowDebugLines()
	{
		foreach (GameObject def in GameObject.FindGameObjectsWithTag("Defender")) {

			Quaternion rotMin = Quaternion.AngleAxis (minBotAngle, Vector3.forward);
			Quaternion rotMax = Quaternion.AngleAxis (maxTopAngle, Vector3.forward);

			Vector3 botLine = rotMin * Vector3.right;
			Vector3 topLine = rotMax * Vector3.right;

			Gizmos.color = Color.red;
			Gizmos.DrawRay (def.transform.position, botLine);
			Gizmos.DrawRay (def.transform.position, topLine);
		}
	}

	void OnDrawGizmos()
	{
		if (showDebugAngles) {
			ShowDebugLines ();
		}
	}

}
