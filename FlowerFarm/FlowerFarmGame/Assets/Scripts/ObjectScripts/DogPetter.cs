using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;


public class DogPetter : MonoBehaviour, IInteractable
{
    private bool isFollow;
    public static event Action<bool> DogPetted;
    public AudioSource dogWoof;

    void Start()
    {
        isFollow = false;
    }
    public void Interact()
    {
        dogWoof.Play();
        if (isFollow == false)
        {
            isFollow = true;
            DogPetted?.Invoke(isFollow); 
        }
        else if (isFollow == true)
        {
            isFollow = false;
            DogPetted?.Invoke(isFollow);
        }
        
        
    }
}