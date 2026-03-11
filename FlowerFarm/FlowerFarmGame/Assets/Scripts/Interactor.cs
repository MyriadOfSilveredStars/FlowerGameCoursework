using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

interface IInteractable
{
   public void Interact();
}

public class Interactor : MonoBehaviour
{
    public GameObject Crosshair;
    public GameObject InteractPromptCrosshair;

    public Transform InteractorSource;
    public float InteractRange;

    void Start()
    {
        
    }

    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObject))
            {
                Crosshair.SetActive(false);
                InteractPromptCrosshair.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObject.Interact();
                }
                
            }
            else
            {
                Crosshair.SetActive(true);
                InteractPromptCrosshair.SetActive(false);
            }
            }
    }
}