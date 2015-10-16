using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

	// Use this for initialization
	private Dictionary<string,int> keepTrackOf;

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

	}

	void ResetLevelScene()
	{
	}

	void PreLevelLoadActions()
	{
		ResetLevelScene ();
	}

	void PostLevelLoadActions()
	{
	}

	public void Add(string s, int i)
	{
		keepTrackOf [s] = i;
	}

	public void Subtract(string s, int i)
	{
		if (keepTrackOf[s] >= 0) {
			keepTrackOf[s] -= 0;
		}
	}

	public int GetTrackedValue(string s)
	{
		return keepTrackOf [s];
	}
}
