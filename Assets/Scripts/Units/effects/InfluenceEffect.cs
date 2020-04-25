using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceEffect : Effect
{
    public InfluenceEffect(UnitBase unitBase, Zone zone, GameObject materialHolder): base(unitBase, zone, materialHolder) {
        name = "Influence";
        description = "Increases the influence of buildings on the field by given value. Some buildings can be placed only if a field has a sufficent amount of influence.";
        myMaterial = materialHolder.GetComponent<MaterialHolder>().influence;
    }

    protected override void computeOne(GridElement gridElement, int value) {
        gridElement.earthCounters["influence"] += value;
    }
    protected override void performOne(GridElement gridElement, int value) {
        
    }
}
