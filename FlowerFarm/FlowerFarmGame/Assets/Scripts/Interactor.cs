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
        try
        {
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObject))
                    {
                        CrosshairText.text = "Interact [E]";
                        if (Input.GetKeyDown(KeyCode.E))
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
        catch
        {
            Debug.Log("If an item is null, for some reason, this will be thrown");
        }
        
    }
}