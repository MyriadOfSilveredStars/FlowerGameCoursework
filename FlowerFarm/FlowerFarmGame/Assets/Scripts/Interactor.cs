using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

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
                if (Input.GetKeyDown(KeyCode.E) && interactObject != null)
                {
                    interactObject.Interact();
                }
                
            }
            else
            {
                CrosshairText.text = "";
            }
        }
        
    }
}