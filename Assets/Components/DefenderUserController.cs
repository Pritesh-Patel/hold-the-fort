using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefenderUserController : MonoBehaviour {

	// Use this for initialization
	public List<GameObject> defenders;
	public float maxTopAngle;
	public float minBotAngle;
	public bool showDebugAngles;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void AimAtMouse(GameObject def)
	{
		Transform defTran = def.transform;


	}

	public void ShowDebugLines()
	{
		foreach (GameObject def in defenders) {

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
		if (showDebugAngles)
			ShowDebugLines ();
	}

}
