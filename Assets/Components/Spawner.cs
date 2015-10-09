using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Use this for initialization
	private Timer timer;
	public Spawnable spawn;
	public GameObject spawnPoint;
	public Transform spawnTransform;
	private bool spawning = false;

	public float spawnInterval;

	void Start () {
		timer = GetComponent<Timer> ();
		spawnTransform = spawnPoint.transform;
		timer.StartTimer (0);
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
