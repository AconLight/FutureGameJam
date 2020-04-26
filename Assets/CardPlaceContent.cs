using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPlaceContent : MonoBehaviour
{
    public GameObject unit, cardContent;

    public Sprite missingSprite;
    public GameObject gridElement;
    public GameObject GameEngine;

    public Text attackText; 
    public Text influenceText; 
    public Text moveText;

    public Text influence;

    public Text healthText;
    public Text actionPointsText;
    public Text inciativeText;
    public Text requiredInfluenceText;
    public Text speedText;
    public Text maxSpeedText;

    private static Color activeColor = new Color(0.196f,0.196f,0.196f,1);
    private static Color disabledColor = Color.gray;

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
        var gridScript = gridElement.GetComponent<GridElement>();

        if (gridScript.unit != null && !gridScript.isPlaceholder) return;
        if (GameEngine.GetComponent<GameEngine>().stateManager.gameState == GameState.BATTLETURN) return;
        
        Debug.Log("influence: " + gridScript.earthCounters["influence"]);
        Debug.Log("req influence: " + cardContent.GetComponent<CardContent>().getUnit().GetComponent<UnitBase>().unitCounters["reqInfluence"]);

        if (gridScript.earthCounters["influence"] < cardContent.GetComponent<CardContent>().getUnit().GetComponent<UnitBase>().unitCounters["reqInfluence"]) {
            return;
        }

        if (gridScript.isPlaceholder) {
            this.unit.transform.SetParent(cardContent.transform);
            this.unit.transform.position = new Vector3(-999999, 0, 0);
        }
        
        this.cardContent = cardContent;
        this.unit = cardContent.GetComponent<CardContent>().getUnit();

        GameEngine.GetComponent<GameEngine>().spawn(unit, gridElement);
        gridScript.isPlaceholder = true;

        var unitScript = unit.GetComponent<UnitBase>();

        var unitDescription = unitScript.unitDescription;

        Text title = gameObject.GetComponentsInChildren<Text>()[0];
        title.text = unitDescription.cardName;

        Text description = gameObject.GetComponentsInChildren<Text>()[1];
        description.text = unitDescription.cardDescription;

        var afterEffects = unitScript.afterEffects;
        var beforeEffects = unitScript.beforeEffects;

        bool attackSet = false;
        bool influenceSet = false;
        bool moveSet = false;

        foreach (var ae in afterEffects)
        {
            if(ae.GetType() == typeof(AttackEffect)) {
                attackText.color = activeColor;
                attackSet = true;
                attackText.GetComponent<Stat>().effect = ae;
            }
            if(ae.GetType() == typeof(MoveEffect)) {
                moveText.color = activeColor;
                moveSet = true;
                moveText.GetComponent<Stat>().effect = ae;
            }
        }

        foreach (var be in beforeEffects)
        {
            if(be.GetType() == typeof(InfluenceEffect)) {
                influenceText.color = activeColor;
                influenceSet = true;
                influenceText.GetComponent<Stat>().effect = be;
            }
        }

        attackText.text = "Attack";
        if(!attackSet) attackText.color = disabledColor;
        
        influenceText.text = "Influence";
        if(!influenceSet) influenceText.color = disabledColor;

        moveText.text = "Move";
        if(!moveSet) moveText.color = disabledColor;

        influence.text = "Influence: " + gridScript.earthCounters["influence"];

        if(unitScript) 
        {
            healthText.text = "Health: " + unitScript.unitCounters["hp"];
            inciativeText.text = "Iniciative: " + unitScript.unitCounters["iniciative"];
            requiredInfluenceText.text = "Req. influence: " + unitScript.unitCounters["reqInfluence"];
            actionPointsText.text = "Action points: " + unitScript.unitCounters["ap"] + "/" + unitScript.unitCounters["apMax"];
            speedText.text = "Speed: " + unitScript.unitCounters["speed"];
            maxSpeedText.text = "Max speed: " + unitScript.unitCounters["maxSpeed"];
        }
        else
        {
            resetUnitStats();
        }



        
     

        RawImage sprite = gameObject.GetComponentsInChildren<RawImage>()[0];
        sprite.GetComponent<RawImage>().texture = unit.GetComponent<UnitBase>().sprite.texture;
    }

    public void resetUnitStats() {
        healthText.text = "";
        inciativeText.text = "";
        requiredInfluenceText.text = "";
        actionPointsText.text = "";
        speedText.text = "";
        maxSpeedText.text = "";
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

            var unitScript = unit.GetComponent<UnitBase>();
             var afterEffects = unitScript.afterEffects;
            var beforeEffects = unitScript.beforeEffects;

            bool attackSet = false;
            bool influenceSet = false;
            bool moveSet = false;

            foreach (var ae in afterEffects)
            {
                if(ae.GetType() == typeof(AttackEffect)) {
                    attackText.color = activeColor;
                    attackSet = true;
                    attackText.GetComponent<Stat>().effect = ae;
                }
                if(ae.GetType() == typeof(MoveEffect)) {
                    moveText.color = activeColor;
                    moveSet = true;
                    moveText.GetComponent<Stat>().effect = ae;
                }
            }

            foreach (var be in beforeEffects)
            {
                if(be.GetType() == typeof(InfluenceEffect)) {
                    influenceText.color = activeColor;
                    influenceSet = true;
                    influenceText.GetComponent<Stat>().effect = be;
                }
            }

            attackText.text = "Attack";
            if(!attackSet) attackText.color = disabledColor;
            
            influenceText.text = "Influence";
            if(!influenceSet) influenceText.color = disabledColor;

            moveText.text = "Move";
            if(!moveSet) moveText.color = disabledColor;

            RawImage sprite = gameObject.GetComponentsInChildren<RawImage>()[0];
            sprite.GetComponent<RawImage>().texture = unit.GetComponent<UnitBase>().sprite.texture;
        } else {
            Text title = gameObject.GetComponentsInChildren<Text>()[0];
            Text description = gameObject.GetComponentsInChildren<Text>()[1];
            title.text = "Drag a card here";
            description.text = "";
            attackText.GetComponent<Stat>().effect = null;
            influenceText.GetComponent<Stat>().effect = null;
            moveText.GetComponent<Stat>().effect = null;
            RawImage sprite = gameObject.GetComponentsInChildren<RawImage>()[0];
            sprite.GetComponent<RawImage>().texture = missingSprite.texture;
        }
    }

    public void acceptCard() {
        gridElement.GetComponent<GridElement>().cb.transform.localPosition = new Vector3(0,-1.7f,0);
        gridElement.GetComponent<GridElement>().isPlaceholder = false;
        GameEngine.GetComponent<GameEngine>().endTurn();
        int i = 0;
        foreach(CardContent cc in transform.parent.gameObject.GetComponentsInChildren<CardContent>()) {
            Debug.Log("moved");
            if (cc.gameObject != cardContent) {
                cc.transform.position = new Vector2(100 + i*200, 100);
                i++;
            }
        }
        cardContent.GetComponent<CardContent>().DestroyMe();
        transform.position = new Vector3(-9999, transform.position.y, transform.position.z);
        cardContent = null;
        gridElement = null;
        unit = null;
    }
}
