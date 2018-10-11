using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public bool _pressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }
}