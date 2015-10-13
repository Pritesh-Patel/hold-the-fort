using UnityEngine;
using System.Collections;

public class PlayGameButton : MonoBehaviour 
{	
	public void PlayButton(string levelName)
	{
		Application.LoadLevel(levelName);
	}
}