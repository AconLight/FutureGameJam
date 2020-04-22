using System;
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
    public GameObject _audioMenager;
    public GameObject audioMenager;
    // Start is called before the first frame update
    public void Start()
    {
        Instantiate (animationObject, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity, this.transform);
    }
    //dupa
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
        UnityEngine.Debug.Log("perform after effects unit base");
        foreach(Effect effect in afterEffects){
            UnityEngine.Debug.Log("compute one after effects unit base");
            effect.compute();
        }
        foreach(Effect effect in afterEffects){
            UnityEngine.Debug.Log("perform one after effects unit base");
            effect.perform();
        }
    }

    public void destroyMe() {
        Destroy(gameObject);
    }
}
