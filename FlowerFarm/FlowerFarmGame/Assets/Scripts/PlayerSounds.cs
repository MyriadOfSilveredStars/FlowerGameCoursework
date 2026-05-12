using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource walkingSound;

    public void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                walkingSound.enabled = false; //don't play walking noise when jumping
            }
            walkingSound.enabled = true;
        }
        else
        {
            walkingSound.enabled = false;
        }
    }
}