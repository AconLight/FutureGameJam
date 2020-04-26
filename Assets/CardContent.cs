using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardContent : MonoBehaviour
{

    public Image _mozdziez;
    public Image _sciana;
    public Image _granatnik;
    public Image _fort;
    public Image _strzelec;

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

        Image image = this.GetComponent<Image>();
        Text influence = gameObject.GetComponentsInChildren<Text>()[2];
        influence.text =  "Req. influence: " + unit.GetComponent<UnitBase>().unitCounters["reqInfluence"]; //unitDescription.cardDescription;

        if(unitDescription.cardName.Equals("Ściana"))
        {
            gameObject.GetComponent<Image>().sprite = _sciana.sprite;
        }
        else if (unitDescription.cardName.Equals("Fort"))
        {
            gameObject.GetComponent<Image>().sprite = _fort.sprite;
        }
        else if (unitDescription.cardName.Equals("Strzelec"))
        {
            gameObject.GetComponent<Image>().sprite = _strzelec.sprite;
        }
        else if (unitDescription.cardName.Equals("Moździeż"))
        {
            gameObject.GetComponent<Image>().sprite = _mozdziez.sprite;
        }
        else if (unitDescription.cardName.Equals("Bunkier"))
        {
            gameObject.GetComponent<Image>().sprite = _granatnik.sprite;
        }

        //gameObject.GetComponent<Image>().sprite = _mozdziez.sprite;



        RawImage sprite = gameObject.GetComponentsInChildren<RawImage>()[0];
        sprite.GetComponent<RawImage>().texture = unit.GetComponent<UnitBase>().sprite.texture;
    }
}
