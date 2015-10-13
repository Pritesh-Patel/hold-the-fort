using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour 
{	
	public void redirectToScene(string sceneName)
	{
		Application.LoadLevel(sceneName);
	}
}