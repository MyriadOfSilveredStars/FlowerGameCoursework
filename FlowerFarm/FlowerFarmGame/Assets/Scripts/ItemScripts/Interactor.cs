using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.EventSystems;
using System;

interface IInteractable
{
   public void Interact();
}

public class Interactor : MonoBehaviour
{
    public GameObject Crosshair;
    public TMP_Text CrosshairText;

    public Transform InteractorSource;
    public float InteractRange;

    public static event Action<bool> TalkingTime;

    void Start()
    {
        CrosshairText.text = "";
    }

    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObject))
            {
                CrosshairText.text = "Interact [E]";
                TalkingTime?.Invoke(true); //if you are interacting with the merchant, the animation will change
                if (Input.GetKeyDown(KeyCode.E) && interactObject != null)
                {
                    interactObject.Interact();
                }
                
            }
            else
            {
                CrosshairText.text = "";
                TalkingTime?.Invoke(false);
            }
        }
        
    }
}