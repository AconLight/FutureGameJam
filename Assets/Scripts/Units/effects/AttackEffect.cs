using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : Effect
{
    public AttackEffect(UnitBase unitBase, Zone zone): base(unitBase, zone) {

    }

    protected override void computeOne(GridElement gridElement, int value) {
        
    }

    protected override void performOne(GridElement gridElement, int value) {
        if (gridElement.unit != null && unitBase.unitCounters["isEnemy"] != gridElement.unit.GetComponent<UnitBase>().unitCounters["isEnemy"]) {
            gridElement.unit.GetComponent<UnitBase>().unitCounters["hp"] -= value;
            if (gridElement.unit.GetComponent<UnitBase>().unitCounters["hp"] <= 0) {
                //gridElement.unit.GetComponent<UnitBase>().destroyMe();
            }
        }
    }
}
