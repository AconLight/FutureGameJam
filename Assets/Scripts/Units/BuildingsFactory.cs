using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsFactory: MonoBehaviour
{
    public GameObject basicBuildingPrefab, bishopPrefab, sniperTowerExploAmmo, turtle, mortar, wall, sniperTower;
    public GameObject card;

    public GameObject materialHolder;
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

    public GameObject getMain() {
        GameObject ret = Instantiate(basicBuildingPrefab, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
        BasicBuilding(ret.GetComponent<UnitBase>());
        //Debug.Log("load size: " + ret.GetComponent<UnitBase>().afterEffects.Count);
        return ret;
    }

    public GameObject getBishop() {
        GameObject ret = Instantiate(bishopPrefab, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
        Bishop(ret.GetComponent<UnitBase>());
        //Debug.Log("load size: " + ret.GetComponent<UnitBase>().afterEffects.Count);
        return ret;
    }
    public GameObject getTurtle() {
        GameObject ret = Instantiate(turtle, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
        Turtle(ret.GetComponent<UnitBase>());
        //Debug.Log("load size: " + ret.GetComponent<UnitBase>().afterEffects.Count);
        return ret;
    }
    public GameObject getMortar() {
        GameObject ret = Instantiate(mortar, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
        Mortar(ret.GetComponent<UnitBase>());
        //Debug.Log("load size: " + ret.GetComponent<UnitBase>().afterEffects.Count);
        return ret;
    }
    public GameObject getSniperTower() {
        GameObject ret = Instantiate(sniperTower, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
        SniperTower(ret.GetComponent<UnitBase>());
        //Debug.Log("load size: " + ret.GetComponent<UnitBase>().afterEffects.Count);
        return ret;
    }
    public GameObject getSniperTowerExploAmmo() {
        GameObject ret = Instantiate(sniperTowerExploAmmo, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
        SniperTowerExploAmmo(ret.GetComponent<UnitBase>());
        //Debug.Log("load size: " + ret.GetComponent<UnitBase>().afterEffects.Count);
        return ret;
    }
    public GameObject getWall() {
        GameObject ret = Instantiate(wall, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
        Wall(ret.GetComponent<UnitBase>());
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
        deck.Add(getWall());
        deck.Add(getMortar());
        deck.Add(getSniperTower());
        deck.Add(getTurtle());
        deck.Add(getSniperTowerExploAmmo());
        deck.Add(getWall());
        deck.Add(getWall());
        deck.Add(getWall());
        deck.Add(getWall());
        deck.Add(getMortar());
        deck.Add(getSniperTower());
        deck.Add(getTurtle());
        deck.Add(getSniperTowerExploAmmo());
        deck.Add(getWall());
        deck.Add(getWall());
        deck.Add(getWall());
    }

    private int handSize = 5;
    public void createHand() {
        System.Random rand = new System.Random();
        for (int i = 0; i < handSize; i++) {
            int id = rand.Next(deck.Count);
            addCardToHand(deck[id], i*200);
            deck.RemoveAt(id);
        }
    }

    public void fillHand() {
        System.Random rand = new System.Random();
        int id = rand.Next(0, deck.Count-1);
        addCardToHand(deck[id], (handSize-1)*200);
        deck.RemoveAt(id);
    }

    public void BasicBuilding(UnitBase unit) {
        //Debug.Log("building load");
        unit.unitCounters.Add("ap", 1);
        unit.unitCounters.Add("apMax", 1);
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("reqInfluence", 1);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 0);
        unit.audioMenager = Instantiate(unit._audioMenager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        unit.audioMenager.GetComponent<AudioMenager>().initAudio("building");
        unit.unitDescription.setCardDescription("Super Karciora", "Karciora zrodzona z głębi odchłani kibla publicznego");
        unit.beforeEffects.Add(new InfluenceEffect(unit, Zone.frame(1), materialHolder));
        unit.afterEffects.Add(new AttackEffect(unit, Zone.frame(1), materialHolder));
    }

    public void Bishop(UnitBase unit) {
        //Debug.Log("building load");
        unit.unitCounters.Add("ap", 1);
        unit.unitCounters.Add("apMax", 1);
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("reqInfluence", 2);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 0);
        unit.audioMenager = Instantiate(unit._audioMenager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        unit.audioMenager.GetComponent<AudioMenager>().initAudio("building");
        unit.unitDescription.setCardDescription("Średnia Karciora", "Karciora zrodzona z najtwardszych gołębi po tej stronie Retkini");
        unit.beforeEffects.Add(new InfluenceEffect(unit, Zone.frame(1), materialHolder));
        unit.afterEffects.Add(new AttackEffect(unit, Zone.frame(1), materialHolder));
    }
    public void Turtle(UnitBase unit)
    {
        unit.unitCounters.Add("ap", 1);
        unit.unitCounters.Add("apMax", 1);
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("reqInfluence", 3);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 0);
        unit.audioMenager = Instantiate(unit._audioMenager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        unit.audioMenager.GetComponent<AudioMenager>().initAudio("building");
        unit.unitDescription.setCardDescription("Bunkier", "Stworzona do walki na krótkim dystansie");
        unit.beforeEffects.Add(new InfluenceEffect(unit, Zone.frame(1), materialHolder));
        int[,] zone = 
        {
            {1,0,0,0,1},
            {0,2,1,2,0},
            {0,1,0,1,0},
            {0,2,1,2,0},
            {1,0,0,0,1},
        };
        unit.afterEffects.Add(new AttackEffect(unit, new Zone(zone), materialHolder));
    }
    public void Mortar(UnitBase unit)
    {
        unit.unitCounters.Add("ap", 1);
        unit.unitCounters.Add("apMax", 1);
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("reqInfluence", 2);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 0);
        unit.audioMenager = Instantiate(unit._audioMenager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        unit.audioMenager.GetComponent<AudioMenager>().initAudio("building");
        unit.unitDescription.setCardDescription("Moździeż", "Nieskuteczna na bliskim dystanicie");
        unit.beforeEffects.Add(new InfluenceEffect(unit, Zone.frame(2), materialHolder));
        int[,] zone = 
        {
            {1,2,2,2,1},
            {2,0,0,0,2},
            {2,0,0,0,2},
            {2,0,0,0,2},
            {1,2,2,2,1},
        };
        unit.afterEffects.Add(new AttackEffect(unit, new Zone(zone), materialHolder));
    }
    public void SniperTower(UnitBase unit)
    {
        unit.unitCounters.Add("ap", 1);
        unit.unitCounters.Add("apMax", 1);
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("reqInfluence", 1);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 0);
        unit.audioMenager = Instantiate(unit._audioMenager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        unit.audioMenager.GetComponent<AudioMenager>().initAudio("building");
        unit.unitDescription.setCardDescription("Strzelec", "Sprzątnie zombiaka z odległości 3 klocków");
        unit.beforeEffects.Add(new InfluenceEffect(unit, Zone.frame(1), materialHolder));
        int[,] zone = 
        {
            {0,0,1,0,0},
            {0,0,2,0,0},
            {1,2,0,2,1},
            {0,0,2,0,0},
            {0,0,1,0,0},
        };
        unit.afterEffects.Add(new AttackEffect(unit, new Zone(zone), materialHolder));
    }
    public void SniperTowerExploAmmo(UnitBase unit)
    {
        unit.unitCounters.Add("ap", 1);
        unit.unitCounters.Add("apMax", 1);
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("reqInfluence", 3);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 0);
        unit.audioMenager = Instantiate(unit._audioMenager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        unit.audioMenager.GetComponent<AudioMenager>().initAudio("building");
        unit.unitDescription.setCardDescription("Fort", "Zasięg niby taki sam ale obrażenia inne");
        unit.beforeEffects.Add(new InfluenceEffect(unit, Zone.frame(1), materialHolder));
        int[,] zone = 
        {
            {0,1,1,1,0},
            {1,0,1,0,1},
            {1,1,0,1,1},
            {1,0,1,0,1},
            {0,1,1,1,0},
        };
        unit.afterEffects.Add(new AttackEffect(unit, new Zone(zone), materialHolder));
    }
    public void Wall(UnitBase unit)
    {
        unit.unitCounters.Add("ap", 1);
        unit.unitCounters.Add("apMax", 1);
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("reqInfluence", 1);
        unit.unitCounters.Add("hp", 10);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 0);
        unit.audioMenager = Instantiate(unit._audioMenager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        unit.audioMenager.GetComponent<AudioMenager>().initAudio("building");
        unit.unitDescription.setCardDescription("Ściana", "Zwykła ściana nic dodać nic ująć");
        unit.beforeEffects.Add(new InfluenceEffect(unit, Zone.frame(2), materialHolder));
        unit.afterEffects.Add(new AttackEffect(unit, new Zone(), materialHolder));
    }


}
