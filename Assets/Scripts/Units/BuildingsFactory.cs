using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsFactory: MonoBehaviour
{
    public GameObject basicBuildingPrefab;
    public GameObject basicBuilding;
    void Start() {
        basicBuilding = Instantiate (basicBuildingPrefab, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity, this.transform);
    }

    int ctr = 0;
    void Update() {
        if (ctr == 5){
            //BasicBuilding(basicBuilding.GetComponent<UnitBase>());
        }
        ctr++;
    }
    public static void BasicBuilding(UnitBase unit) {
        Debug.Log("building load");
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 0);
        unit.unitDescription.setCardDescription("Super Karciora", "Karciora zrodzona z głębi odchłani kibla publicznego");
        unit.beforeEffects.Add(new InfluenceEffect(unit, Zone.frame(1)));
        unit.afterEffects.Add(new AttackEffect(unit, Zone.frame(1)));
    }

    public GameObject getMain() {
        GameObject ret = Instantiate(basicBuilding, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
        BasicBuilding(ret.GetComponent<UnitBase>());
        return ret;
    }
}
