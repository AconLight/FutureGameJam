using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardContent : MonoBehaviour
{
    private GameObject unit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetContent(GameObject unit)
    {
        this.unit = unit;

        var unitDescription = unit.GetComponent<UnitBase>().unitDescription;

        Text title = gameObject.GetComponentsInChildren<Text>()[0];
        title.text = unitDescription.cardName;

        Text description = gameObject.GetComponentsInChildren<Text>()[1];
        description.text = unitDescription.cardDescription;
    }
}
