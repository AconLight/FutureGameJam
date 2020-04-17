using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{  
    public List<Effect> earthEffects;
    public List<Effect> unitEffects;
    public Dictionary<string, int> unitCounters;

    public GameObject animationObject;

    private UnitBase main;
    public void setMain(UnitBase main) {
        this.main = main;
    }

    // Start is called before the first frame update
    public void Start()
    {
        unitCounters = new Dictionary<string, int>();
        unitCounters.Add("iniciative", 1);
        unitEffects = new List<Effect>();
        earthEffects = new List<Effect>();
        earthEffects.Add(new InfluenceEffect(this, Zone.frame(1)));
        Instantiate (animationObject, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity, this.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addEarthCounters() {
        foreach(Effect effect in earthEffects){
            effect.perform();
        }
    }

    public void computeUnitCounters() {
        foreach(Effect effect in unitEffects){
            effect.perform();
        }
    }

    public void makeTurn() {
        Move(1,0);
    }

    public void Move(int x, int z) {
        GameObject gridElement = this.transform.parent.GetComponent<GridElement>().getByXZ(x, z);
        if (gridElement != null && gridElement.GetComponent<GridElement>().unit == null) {
            GridElement oldGridElement = this.transform.parent.gameObject.GetComponent<GridElement>();
            this.transform.SetParent(gridElement.transform);
            gridElement.GetComponent<GridElement>().unit = this.gameObject;
            this.transform.position = gridElement.transform.position;
            oldGridElement.unit = null;
            // TODO animation goes brrrrrr
        } else {
            UnityEngine.Debug.Log("dupa");
        }

    }

    public void Attack() {

    }
}
