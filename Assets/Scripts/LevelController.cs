﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

	// Use this for initialization
	private Dictionary<string,float> keepTrackOf = new Dictionary<string,float>();

	void Start () {
		DontDestroyOnLoad (gameObject);
		keepTrackOf.Add ("score", 0);
		keepTrackOf.Add ("coins", 0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadNewLevel(ELevel lvl)
	{
		PreLevelLoadActions ();
		switch (lvl) 
		{
			case ELevel.Level1:
			{
				Debug.Log ("In Level 1");
				break;

			}
			case ELevel.Level2:
			{
				Debug.Log ("In Level 2");
				break;
					
			}
		}
		PostLevelLoadActions ();

	}

	void ResetLevelScene()
	{
	}

	void PreLevelLoadActions()
	{
		Debug.Log ("Loading new scene");
	}

	void PostLevelLoadActions()
	{
		Debug.Log ("Finnished loading level");
	}

	public void Add(string s, float i)
	{
		keepTrackOf[s] =  keepTrackOf [s] + i;
	}

	public void Subtract(string s, int i)
	{
		if (keepTrackOf[s] >= 0) {
			keepTrackOf[s] -= 0;
		}
	}

	public float GetTrackedValue(string s)
	{
		return keepTrackOf [s];
	}
}
