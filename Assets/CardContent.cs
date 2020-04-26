using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardContent : MonoBehaviour
{
    private GameObject unit;

    public GameObject getUnit() {
        return unit;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyMe() {
        Destroy(gameObject);
    }

    public void SetContent(GameObject unit)
    {
        this.unit = unit;

        var unitDescription = unit.GetComponent<UnitBase>().unitDescription;

        Text title = gameObject.GetComponentsInChildren<Text>()[0];
        title.text = unitDescription.cardName;

        Text description = gameObject.GetComponentsInChildren<Text>()[1];
        description.text = ""; //unitDescription.cardDescription;

        Text influence = gameObject.GetComponentsInChildren<Text>()[2];
        influence.text =  "Req. influence: " + unit.GetComponent<UnitBase>().unitCounters["reqInfluence"]; //unitDescription.cardDescription;


        RawImage sprite = gameObject.GetComponentsInChildren<RawImage>()[0];
        sprite.GetComponent<RawImage>().texture = unit.GetComponent<UnitBase>().sprite.texture;
    }
}
