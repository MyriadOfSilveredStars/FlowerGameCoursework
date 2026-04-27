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


public class TitleButtons : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string buttonName;
    public static event Action<string> OnOptionChosen;
    public static event Action<string, bool> OnOptionHovered;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The " + buttonName + " has been hovered over");
        OnOptionHovered?.Invoke(buttonName, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("The " + buttonName + " is no longer hovered over");
        OnOptionHovered?.Invoke(buttonName, false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Button clicked: " + buttonName);
            OnOptionChosen?.Invoke(buttonName);
        }
    }
}
