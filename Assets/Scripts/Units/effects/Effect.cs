﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    protected GameObject materialHolder;
    public string name, description;
    protected Zone zone;
    protected UnitBase unitBase;

    public Material myMaterial;
    public Effect(UnitBase unitBase, Zone zone, GameObject materialHolder) {
        this.zone = zone;
        this.unitBase = unitBase;
        this.materialHolder = materialHolder;
    }

    public Dictionary<GridElement, int> getAffected() {
        Dictionary<GridElement, int> res = new Dictionary<GridElement, int>();
        if (unitBase == null) return res;
        if (unitBase.transform == null) return res;
        if (unitBase.transform.parent == null) return res;
        if (unitBase.transform.parent.GetComponent<GridElement>() == null) return res;
        GridElement gridElement = unitBase.transform.parent.GetComponent<GridElement>();
        for(int x = 0; x < Zone.size; x++) {
            for(int z = 0; z < Zone.size; z++) {
                GameObject myGridElementObject = gridElement.getByXZ(x-(Zone.size-1)/2, z-(Zone.size-1)/2);
                if (myGridElementObject != null && zone.zoneValues[z,x] != 0) {
                    res.Add(myGridElementObject.GetComponent<GridElement>(), zone.zoneValues[z,x]);
                }
            } 
        }
        return res;
    }

    public virtual void perform() {
        GridElement gridElement = unitBase.transform.parent.GetComponent<GridElement>();
        for(int x = 0; x < Zone.size; x++) {
            for(int z = 0; z < Zone.size; z++) {
                GameObject myGridElementObject = gridElement.getByXZ(x-(Zone.size-1)/2, z-(Zone.size-1)/2);
                if (myGridElementObject != null && zone.zoneValues[z,x] != 0) {
                    performOne(myGridElementObject.GetComponent<GridElement>(), zone.zoneValues[z,x]);
                }
            } 
        }   
    }
    protected abstract void performOne(GridElement gridElement, int value);

    public virtual void compute() {
        GridElement gridElement = unitBase.transform.parent.GetComponent<GridElement>();
        for(int x = 0; x < Zone.size; x++) {
            for(int z = 0; z < Zone.size; z++) {
                GameObject myGridElementObject = gridElement.getByXZ(x-(Zone.size-1)/2, z-(Zone.size-1)/2);
                //Debug.Log(x + ", " + z + "=" + zone.zoneValues[z,x]);
                if (myGridElementObject != null && zone.zoneValues[z,x] != 0) {
                    computeOne(myGridElementObject.GetComponent<GridElement>(), zone.zoneValues[z,x]);
                }
            } 
        }   
    }
    protected abstract void computeOne(GridElement gridElement, int value);
}
