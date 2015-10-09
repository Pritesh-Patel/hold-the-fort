using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	// Use this for initialization

	public float currTime = 0;

	private bool started = false;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (started)
			currTime += Time.time;
	}

	public void StartTimer(int starttime)
	{
		currTime = starttime;
		started = true;
	}

	public void PauseTimer(bool pause)
	{
		started = pause;
	}

	public void ResetTimer()
	{
		currTime = 0;
	}
}
