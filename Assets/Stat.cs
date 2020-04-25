using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Stat : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text statText;

    public Effect effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Boolean isHandledEnter = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isHandledEnter) return;
        isHandledExit = false;
        isHandledEnter = true;
        //If your mouse hovers over the GameObject with the script attached, output this message
        statText.fontSize = 25;
        CardPlaceContent cpc = transform.parent.GetComponent<CardPlaceContent>();
        if (effect == null) return;
        Dictionary<GridElement, int> dic = effect.getAffected();
        List<GridElement> keys = new List<GridElement>(dic.Keys);
        foreach(GridElement ge in keys) {
            Debug.Log(ge.cb.GetComponent<Renderer>().sharedMaterial.name);
            ge.cb.GetComponent<Renderer>().sharedMaterial = effect.myMaterial;
            ge.up(dic[ge]);
        }
    }

    public Boolean isHandledExit = true;
    public void OnPointerExit(PointerEventData eventData)
    {
        if (isHandledExit) return;
        isHandledEnter = false;
        isHandledExit = true;
        //The mouse is no longer hovering over the GameObject so output this message each frame
        statText.fontSize = 20;
        CardPlaceContent cpc = transform.parent.GetComponent<CardPlaceContent>();
        if (effect == null) return;
        Dictionary<GridElement, int> dic = effect.getAffected();
        List<GridElement> keys = new List<GridElement>(dic.Keys);
        foreach(GridElement ge in keys) {
            Debug.Log(ge.cb.GetComponent<Renderer>().sharedMaterial.name);
            ge.cb.GetComponent<Renderer>().sharedMaterial = ge.defaultMaterial;
            ge.down();
        }
    }
}
