using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemValuePuzzle : MonoBehaviour, IDropHandler
{
    public int ItemValue;
    public bool correctMatch;
    public GameObject titleOfBox;

    public DragAndDropPuzzle inputItem;

    void Update()
    {
        titleOfBox.SetActive(correctMatch);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            inputItem = eventData.pointerDrag.GetComponent<DragAndDropPuzzle>();

            if (inputItem.ItemValue == ItemValue)
            {
                correctMatch = true;
            }
        }
    }
}
