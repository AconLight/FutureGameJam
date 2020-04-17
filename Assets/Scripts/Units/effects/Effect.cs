using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    protected InfluenceZoneBase zone;
    protected UnitBase unitBase;
    public Effect(UnitBase unitBase, InfluenceZoneBase zone) {
        this.zone = zone;
        this.unitBase = unitBase;
    }

    public void perform() {
        //  TODO wiktor
        //  for x zone
        //      for z zone
        //          performOne(unit[x][z]);    
    }
    protected abstract void performOne(UnitBase unit, int value);
}
