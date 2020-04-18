using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory
{
    public static void BasicEnemy(UnitBase unit) {
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 1);
        unit.afterEffects.Add(new MoveEffect(unit, Zone.one()));
        unit.afterEffects.Add(new AttackEffect(unit, Zone.frame(1)));
    }
}
