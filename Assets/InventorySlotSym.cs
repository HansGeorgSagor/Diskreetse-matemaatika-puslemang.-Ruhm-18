using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotSym : MonoBehaviour, IDropHandler
{
    public Image defaultImage;
    public string sümbol;

    public void OnDrop(PointerEventData eventData)
    {
        defaultImage.tag = sümbol;
        Debug.Log("Item dropped onto grid layout group.");

        GameObject dropped = eventData.pointerDrag;
        draggableitem Draggableitem = dropped.GetComponent<draggableitem>();

        
        Vector3 newPosition = transform.position;
        newPosition.z = dropped.transform.position.z; 
        dropped.transform.position = newPosition;

        Draggableitem.parentAfterDrag = transform;
    }

    void Update()
    {
        
        if (transform.childCount == 0)
        {
            Debug.Log("Child Count: " + transform.childCount);
            

            GameObject newImage = Instantiate(defaultImage.gameObject, transform);
            newImage.transform.localPosition = Vector3.zero;
            newImage.transform.localScale = Vector3.one;
            newImage.transform.localRotation = Quaternion.identity;

            draggableitem Draggableitem = newImage.GetComponent<draggableitem>();
            Draggableitem.parentAfterDrag = null;

            newImage.tag = sümbol;

        }
        else if (transform.childCount > 1)
        {
            
            for (int i = 1; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
                Debug.Log("image destoyed");
            }
        }
    }
}
