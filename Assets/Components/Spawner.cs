using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Use this for initialization
	private Timer timer;
	public Spawnable spawn;
	public GameObject spawnPoint;
	public Transform spawnTransform;

	private float spawnInterval = 1.0f;

	void Start () {
		timer = GetComponent<Timer> ();
		spawnTransform = spawnPoint.transform;
		timer.StartTimer (0);
	}
	
	// Update is called once per frame
	void Update () {


		if (timer.currTime > spawnInterval) {
			Debug.Log ("Spawning");
			Spawnable spawned = Instantiate (spawn, spawnTransform.position, Quaternion.identity) as Spawnable;
			spawned.Spawned ();
			timer.ResetTimer ();
			if (spawned == null)
				Debug.Log ("Shit its null");
		} else {
			Debug.Log ("Well, shit.");
		}
	
	}
}
