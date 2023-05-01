using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotDelete : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item dropped onto grid layout group.");

        GameObject dropped = eventData.pointerDrag;
        draggableitem Draggableitem = dropped.GetComponent<draggableitem>();

        
        if (Draggableitem != null && Draggableitem.GetComponent<Image>() != null)
        {
           
            if (dropped.transform.parent != null)
            {
                Destroy(dropped);
                Debug.Log("Image destroyed");
            }
            else
            {
                Debug.Log("Invalid drop location. Image not destroyed.");
            }
        }
        else
        {
            Debug.Log("Invalid object dropped.");
        }
    }
}
