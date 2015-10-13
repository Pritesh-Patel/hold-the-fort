using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	private Transform 	spawnTransform;
	private bool 		spawning = false;

	public Spawnable 	spawn;
	public GameObject 	spawnPoint;
	public float 		spawnInterval;

	void Start () {
		spawnTransform = spawnPoint.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (!spawning) {
			StartCoroutine(Spawn());
		}
	}

	IEnumerator Spawn() {
		spawning = true;
		Spawnable spawned = Instantiate (spawn, spawnTransform.position, Quaternion.identity) as Spawnable;
		spawned.Spawned ();
		yield return new WaitForSeconds(spawnInterval);
		spawning = false;
	}
}
