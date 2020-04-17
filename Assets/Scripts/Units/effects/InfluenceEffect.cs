using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceEffect : Effect
{
    public InfluenceEffect(UnitBase unitBase, InfluenceZoneBase zone): base(unitBase, zone) {

    }

    protected override void performOne(UnitBase unit, int value) {
        unit.transform.parent.GetComponent<GridElement>().earthCounters["influence"] += value;
    }
}
