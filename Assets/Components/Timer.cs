using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private bool started = false;

	public float currTime = 0;

	void Update () {	
		if (started) currTime += Time.time;
	}

	public void StartTimer(int startTime)
	{
		currTime = startTime;
		started = true;
	}

	public void ToggleTimer(bool toggle)
	{
		started = toggle;
	}

	public void ResetTimer()
	{
		currTime = 0;
	}
}
