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

    public void OnPointerEnter(PointerEventData eventData)
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        statText.fontSize = 25;
        CardPlaceContent cpc = transform.parent.GetComponent<CardPlaceContent>();
        if (effect == null) return;
        Dictionary<GridElement, int> dic = effect.getAffected();
        List<GridElement> keys = new List<GridElement>(dic.Keys);
        foreach(GridElement ge in keys) {
            Debug.Log("dupa");
            Material[] array = new Material[1];
            array[0] = effect.myMaterial;
            ge.cube.GetComponent<Renderer>().materials = array;
            ge.up(dic[ge]);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        statText.fontSize = 20;
        CardPlaceContent cpc = transform.parent.GetComponent<CardPlaceContent>();
        if (effect == null) return;
        Dictionary<GridElement, int> dic = effect.getAffected();
        List<GridElement> keys = new List<GridElement>(dic.Keys);
        foreach(GridElement ge in keys) {
            Material[] array = new Material[1];
            array[0] = ge.defaultMaterial;
            ge.cube.GetComponent<Renderer>().materials = array;
            ge.down();
        }
    }
}
