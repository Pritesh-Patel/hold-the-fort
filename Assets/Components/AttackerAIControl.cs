using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AttackerAIControl : MonoBehaviour
{
    private Attacker attacker;
	
    private void Awake()
    {
        attacker = GetComponent<Attacker>();
    }


    private void FixedUpdate()
    {
        attacker.Move(0.7f);
    }
}