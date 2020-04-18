using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsFactory
{
    public static void BasicBuilding(UnitBase unit) {
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 0);
        unit.unitDescription.setCardDescription("Super Karciora", "Karciora zrodzona z głębi odchłani kibla publicznego");
        unit.beforeEffects.Add(new InfluenceEffect(unit, Zone.frame(1)));
        unit.afterEffects.Add(new AttackEffect(unit, Zone.frame(1)));
    }
}
