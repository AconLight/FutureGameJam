using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Vector2 startingPosition;
    private Vector2 dragOffset; // This variable is used to store offset from center of draggable object

    void Start()
    {
        startingPosition = this.transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragOffset = (Vector2)this.transform.position - eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position + dragOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(false)
        {
            // TODO place over some object
        }
        else
        {
            this.transform.position = startingPosition;
        }
    }
}
