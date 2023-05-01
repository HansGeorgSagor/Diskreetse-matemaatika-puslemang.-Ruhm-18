using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SlotScript : MonoBehaviour, IDropHandler
{
    public int slotIndex;
    public string expectedImageTag;
    public int expectedImageIndex;
    public CompletionChecker completionChecker; 
    public bool AllCorrectSlot = true;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.tag != null)
        {
            string droppedImageTag = eventData.pointerDrag.tag;

            for (int i = 0; i < completionChecker.numRows; i++)
            {
                if (droppedImageTag == completionChecker.expectedImageTags[i][expectedImageIndex])
                {
                    Debug.Log("Expected image has been dropped into the slot!");
                    completionChecker.SetSlotCorrect(i, slotIndex, true);
                }
                else
                {
                    completionChecker.SetSlotCorrect(i, slotIndex, false);
                }
            }
        }
    }
    
    public void clearslots()
    {
			StartCoroutine(WaitForClear());
	}
	
	private IEnumerator WaitForClear()
	{
		yield return new WaitForSeconds(0.1f);

		if(transform.childCount > 0)
		{
			Debug.Log("Deleting child object.");
			Destroy(transform.GetChild(0).gameObject);
		}
	}

    private void Update()
    {
        if (transform.childCount == 0)
		{
			
			for (int i = 0; i < completionChecker.numRows; i++)
			{
				if (slotIndex < (completionChecker.symarv + 1))
				{
					
					completionChecker.SetSlotCorrect(i, slotIndex, false);
				}
				if(slotIndex >= (completionChecker.symarv + 1))
				{
					completionChecker.SetSlotCorrect(i, slotIndex, true);
				}
			}
		}
	}
}



