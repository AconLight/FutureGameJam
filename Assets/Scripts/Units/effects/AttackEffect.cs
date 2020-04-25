using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : Effect
{
    public AttackEffect(UnitBase unitBase, Zone zone, GameObject materialHolder): base(unitBase, zone, materialHolder) {
        name = "Attack";
        description = "Damages enemies by given value";
        myMaterial = materialHolder.GetComponent<MaterialHolder>().attack;
    }

    protected override void computeOne(GridElement gridElement, int value) {
        
    }

    public override void perform() {
        base.perform();
        base.unitBase.audioMenager.GetComponent<AudioMenager>().playAttack();
    }

    protected override void performOne(GridElement gridElement, int value) {
        if (gridElement.unit != null && unitBase.unitCounters["isEnemy"] != gridElement.unit.GetComponent<UnitBase>().unitCounters["isEnemy"]) {
            gridElement.unit.GetComponent<UnitBase>().unitCounters["hp"] -= value;
            //Debug.Log("attack");
            if (gridElement.unit.GetComponent<UnitBase>().unitCounters["hp"] <= 0) {
                gridElement.unit.GetComponent<UnitBase>().destroyMe();
            }
        }
    }
}
