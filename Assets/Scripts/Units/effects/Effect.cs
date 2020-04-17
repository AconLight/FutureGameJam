using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    protected Zone zone;
    protected UnitBase unitBase;
    public Effect(UnitBase unitBase, Zone zone) {
        this.zone = zone;
        this.unitBase = unitBase;
    }

    public void perform() {
        GridElement gridElement = unitBase.transform.parent.GetComponent<GridElement>();
        for(int x = 0; x < zone.zoneValues.Length; x++) {
            for(int z = 0; z < zone.zoneValues.Length; z++) {
                GameObject myGridElementObject = gridElement.getByXZ(x, z);
                if (myGridElementObject != null) {
                    performOne(myGridElementObject.GetComponent<GridElement>(), zone.zoneValues[z,x]);
                }
            } 
        }   
    }
    protected abstract void performOne(GridElement gridElement, int value);
}
