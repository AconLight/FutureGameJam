using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{  
    public List<Effect> beforeEffects;
    public List<Effect> afterEffects;
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
        afterEffects = new List<Effect>();
        beforeEffects = new List<Effect>();
        Instantiate (animationObject, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity, this.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void performBeforeEffects() {
        foreach(Effect effect in beforeEffects){
            effect.compute();
        }
        foreach(Effect effect in beforeEffects){
            effect.perform();
        }
    }

    public void performAfterEffects() {
        foreach(Effect effect in afterEffects){
            effect.compute();
        }
        foreach(Effect effect in afterEffects){
            effect.perform();
        }
    }

    public void destroyMe() {
        Destroy(gameObject);
    }
}
