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
        //Debug.Log(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (eventData.position.x > 150 && eventData.position.x < 250 &&
            eventData.position.y > 850 && eventData.position.y < 950) {
                transform.parent.GetComponentInChildren<CardPlaceContent>().SetContent(gameObject);
            }

        if(false)
        {
        }
        else
        {
            this.transform.position = startingPosition;
        }
    }
}
