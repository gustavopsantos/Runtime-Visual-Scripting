using UnityEngine;
using UnityEngine.EventSystems;

public class DragNode : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private Vector3 _mouseOffset;

    public void OnPointerDown(PointerEventData eventData)
    {
        _mouseOffset = transform.position - GetMouseWorldPosition();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = GetMouseWorldPosition() + _mouseOffset;
    }

    private static Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}