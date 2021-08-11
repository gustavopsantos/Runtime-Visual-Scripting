using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Graphic))]
public class GraphicEventTrigger : MonoBehaviour, IDragHandler, IDropHandler
{
    public event Action<PointerEventData> OnDrag = delegate { };
    public event Action<PointerEventData> OnDrop = delegate { };

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        OnDrop(eventData);
    }
}