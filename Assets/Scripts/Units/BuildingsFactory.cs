using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsFactory: MonoBehaviour
{
    public GameObject basicBuildingPrefab;
    public GameObject card;
    //public GameObject basicBuilding;
    void Start() {
        //basicBuilding = Instantiate (basicBuildingPrefab, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity, this.transform);
    }

    int ctr = 0;
    void Update() {
        if (ctr == 5){
            //BasicBuilding(basicBuilding.GetComponent<UnitBase>());
        }
        ctr++;
    }
    public static void BasicBuilding(UnitBase unit) {
        //Debug.Log("building load");
        unit.unitCounters.Add("ap", 1);
        unit.unitCounters.Add("apMax", 1);
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 0);
        unit.audioMenager = Instantiate(unit._audioMenager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        unit.audioMenager.GetComponent<AudioMenager>().initAudio("building");
        unit.unitDescription.setCardDescription("Super Karciora", "Karciora zrodzona z głębi odchłani kibla publicznego");
        unit.beforeEffects.Add(new InfluenceEffect(unit, Zone.frame(1)));
        unit.afterEffects.Add(new AttackEffect(unit, Zone.frame(1)));
    }

    public GameObject getMain() {
        GameObject ret = Instantiate(basicBuildingPrefab, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
        BasicBuilding(ret.GetComponent<UnitBase>());
        //Debug.Log("load size: " + ret.GetComponent<UnitBase>().afterEffects.Count);
        return ret;
    }

    private void addCardToHand(GameObject unit, float posX) {
        // Tu se dodałem tworzenie karty
        GameObject r = Instantiate(card, new Vector2(posX + 100, 100), Quaternion.identity) as GameObject;
        r.transform.parent = GameObject.Find("Canvas").transform;
        r.GetComponent<CardContent>().SetContent(unit);
    }

    private List<GameObject> deck = new List<GameObject>();
    public void createDeck() {
        deck.Add(getMain());
        deck.Add(getMain());
        deck.Add(getMain());
    }

    private int handSize = 3;
    public void createHand() {
        System.Random rand = new System.Random();
        for (int i = 0; i < handSize; i++) {
            int id = rand.Next(deck.Count);
            addCardToHand(deck[id], i*200);
            deck.RemoveAt(id);
        }
    }
}
