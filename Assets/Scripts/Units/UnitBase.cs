﻿using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{  
    public GameObject animationObject;
    private UnitBase main;
    public void setMain(UnitBase main) {
        this.main = main;
    }

    public Dictionary<string, int> unitCounters = new Dictionary<string, int>();
    public List<Effect> afterEffects = new List<Effect>();
    public List<Effect> beforeEffects = new List<Effect>();
    public UnitDescription unitDescription = new UnitDescription();
    public AudioMenager _audioMenager;
    public AudioMenager audioMenager;
    // Start is called before the first frame update
    public void Start()
    {
        unitCounters = new Dictionary<string, int>();
        afterEffects = new List<Effect>();
        beforeEffects = new List<Effect>();
        unitDescription = new UnitDescription();
        audioMenager = Instantiate(_audioMenager, new Vector3(0, 0, 0), Quaternion.identity);
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
