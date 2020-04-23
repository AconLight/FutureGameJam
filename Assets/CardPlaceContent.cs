﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPlaceContent : MonoBehaviour
{
    public GameObject unit, cardContent;

    public Sprite missingSprite;
    public GameObject gridElement;
    public GameObject GameEngine;

    // Start is called before the first frame update
    void Start()
    {
        Button button = gameObject.GetComponentsInChildren<Button>()[0];
        button.onClick.AddListener(acceptCard);
        RawImage sprite = gameObject.GetComponentsInChildren<RawImage>()[0];
        sprite.GetComponent<RawImage>().texture = missingSprite.texture;
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

        public void SetByGridElement(GameObject elem)
    {
        this.unit = elem.GetComponent<GridElement>().unit;

        if (unit != null) {
            var unitDescription = unit.GetComponent<UnitBase>().unitDescription;

            Text title = gameObject.GetComponentsInChildren<Text>()[0];
            title.text = unitDescription.cardName;

            Text description = gameObject.GetComponentsInChildren<Text>()[1];
            description.text = unitDescription.cardDescription;

            RawImage sprite = gameObject.GetComponentsInChildren<RawImage>()[0];
            sprite.GetComponent<RawImage>().texture = unit.GetComponent<UnitBase>().sprite.texture;
        } else {
            Text title = gameObject.GetComponentsInChildren<Text>()[0];
            Text description = gameObject.GetComponentsInChildren<Text>()[1];
            title.text = "Drag a card here";
            description.text = "";
            RawImage sprite = gameObject.GetComponentsInChildren<RawImage>()[0];
            sprite.GetComponent<RawImage>().texture = missingSprite.texture;
        }
    }

    public void acceptCard() {
        GameEngine.GetComponent<GameEngine>().spawn(unit, gridElement);
        GameEngine.GetComponent<GameEngine>().endTurn();
        cardContent.GetComponent<CardContent>().DestroyMe();
        transform.position = new Vector3(-9999, transform.position.y, transform.position.z);
        cardContent = null;
        gridElement = null;
        unit = null;
    }
}
