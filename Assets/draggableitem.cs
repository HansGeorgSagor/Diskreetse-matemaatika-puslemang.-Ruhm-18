using UnityEngine;
using UnityEngine.EventSystems;

public class draggableitem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        Debug.Log("Image clicked");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, Camera.main.nearClipPlane));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        InventorySlot inventorySlot = eventData.pointerCurrentRaycast.gameObject.GetComponent<InventorySlot>();

        if (inventorySlot != null)
        {
            transform.SetParent(inventorySlot.transform);
            transform.position = inventorySlot.transform.position;
        }
        else
        {
            transform.SetParent(parentAfterDrag);
            transform.position = parentAfterDrag.position;
        }
    }
}
