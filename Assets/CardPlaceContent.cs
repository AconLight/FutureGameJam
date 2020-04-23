using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPlaceContent : MonoBehaviour
{
    private GameObject unit, cardContent;

    public GameObject gridElement;
    public GameObject GameEngine;

    // Start is called before the first frame update
    void Start()
    {
        Button button = gameObject.GetComponentsInChildren<Button>()[0];
        button.onClick.AddListener(acceptCard);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetContent(GameObject cardContent)
    {
        this.cardContent = cardContent;
        this.unit = cardContent.GetComponent<CardContent>().getUnit();

        var unitDescription = unit.GetComponent<UnitBase>().unitDescription;

        Text title = gameObject.GetComponentsInChildren<Text>()[0];
        title.text = unitDescription.cardName;

        Text description = gameObject.GetComponentsInChildren<Text>()[1];
        description.text = unitDescription.cardDescription;


        RawImage sprite = gameObject.GetComponentsInChildren<RawImage>()[0];
        sprite.GetComponent<RawImage>().texture = unit.GetComponent<UnitBase>().sprite.texture;
    }

    public void acceptCard() {
        GameEngine.GetComponent<GameEngine>().spawn(unit, gridElement);
        cardContent.GetComponent<CardContent>().DestroyMe();
    }
}
