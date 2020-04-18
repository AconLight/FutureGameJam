using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : Effect
{
    public MoveEffect(UnitBase unitBase, Zone zone): base(unitBase, zone) {

    }

    protected override void computeOne(GridElement gridElement, int value) {
        if (value != 1) return;
        UnityEngine.Debug.Log("value: " + value);
        
        int x = 0;
        int z = 1;
        // TODO A* for x,z
        GameObject gridElementObject = gridElement.getByXZ(x, z);
        if (gridElementObject != null && gridElementObject.GetComponent<GridElement>().unit == null) {
            GridElement oldGridElement = unitBase.transform.parent.gameObject.GetComponent<GridElement>();
            unitBase.transform.SetParent(gridElementObject.transform);
            gridElementObject.GetComponent<GridElement>().unit = unitBase.gameObject;
            unitBase.transform.position = gridElementObject.transform.position;
            oldGridElement.unit = null;
            // TODO animation goes brrrrrr
        } else {
            UnityEngine.Debug.Log("dupa");
        }
    }

    protected override void performOne(GridElement gridElement, int value) {

    }
}
