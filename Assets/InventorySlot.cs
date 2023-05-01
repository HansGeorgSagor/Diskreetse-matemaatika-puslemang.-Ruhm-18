using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item dropped onto grid layout group.");

        GameObject dropped = eventData.pointerDrag;
        draggableitem Draggableitem = dropped.GetComponent<draggableitem>();

        Vector3 newPosition = transform.position;
        newPosition.z = dropped.transform.position.z; 
        dropped.transform.position = newPosition;

        Draggableitem.parentAfterDrag = transform;
    }

	
	
}
