using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceEffect : Effect
{
    public InfluenceEffect(UnitBase unitBase, Zone zone): base(unitBase, zone) {

    }

    protected override void performOne(GridElement gridElement, int value) {
        gridElement.earthCounters["influence"] += value;
    }
}
