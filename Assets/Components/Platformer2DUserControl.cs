using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof (PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;
	
    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
    }


    private void FixedUpdate()
    {
        m_Character.Move(0.7f);
    }
}

