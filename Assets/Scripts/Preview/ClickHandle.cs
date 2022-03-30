using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OnClick();

public class ClickHandle : MonoBehaviour, IPointerDownHandler
{
    public BoxCollider2D clickCollider;

    public event OnClick onClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        onClick?.Invoke();
    }
}
