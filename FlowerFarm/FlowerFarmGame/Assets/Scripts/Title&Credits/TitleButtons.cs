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


public class TitleButtons : MonoBehaviour, IPointerClickHandler
{
    public string buttonName;
    public static event Action<string> OnOptionChosen;


    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Button clicked: " + buttonName);
            OnOptionChosen?.Invoke(buttonName);
        }
    }
}
