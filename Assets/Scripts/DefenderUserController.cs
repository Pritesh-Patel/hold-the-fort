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
		//accounts for the difference in defender postions
		List<Vector3> aimPoints = new List<Vector3> ();
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 distance = defenders[0].transform.position - defenders[1].transform.position;
		Vector3 aimPoint2 = new Vector3 (mousePos.x + Mathf.Abs(distance.x), mousePos.y + Mathf.Abs (distance.y), mousePos.z);
		distance = defenders [1].transform.position - defenders [2].transform.position;
		Vector3 aimPoint3 = new Vector3 (aimPoint2.x + Mathf.Abs(distance.x), mousePos.y + Mathf.Abs (distance.y), mousePos.z);
		aimPoints.Add (mousePos);
		aimPoints.Add (aimPoint2);
		aimPoints.Add(aimPoint3);

		int itt = 0;
		foreach (GameObject def in defenders) {
	
			float radians = Mathf.Atan2(aimPoints[itt].y - def.transform.position.y,aimPoints[itt].x - def.transform.position.x);
			float degrees = radians * (180/Mathf.PI);

			//if (Quaternion.Euler(0,0,degrees)< upper) degrees = maxTopAngle;
			//if (degrees < minBotAngle) degrees = minBotAngle;
			def.transform.rotation = Quaternion.Euler(0, 0, degrees);
			if (showDebugAim)
			{
				Debug.DrawRay(def.transform.position, def.transform.right,Color.green);
			}

			itt++;
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
