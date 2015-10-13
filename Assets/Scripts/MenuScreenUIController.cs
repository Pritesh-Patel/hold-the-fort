using UnityEngine;
using System.Collections;

public class MenuScreenUIController : MonoBehaviour 
{	
	public void redirectToScene(string sceneName)
	{
		Application.LoadLevel(sceneName);
	}
}