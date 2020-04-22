using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory: MonoBehaviour
{
    public GameObject basicEnemyPrefab;
    public GameObject basicEnemy;
    void Start() {
        basicEnemy = Instantiate (basicEnemyPrefab, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity, this.transform);
    }

    int ctr = 0;
    void Update() {
        if (ctr == 5) {
            BasicEnemy(basicEnemy.GetComponent<UnitBase>());
        }
        ctr++;
    }

    public void BasicEnemy(UnitBase unit) {
        Debug.Log("enemy load");
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 1);
        //unit.audioMenager.GetComponent<AudioMenager>().initAudio("menu");
        unit.unitDescription.setCardDescription("Nieumarly alien", "Jeden z pierwszych odkrytych nieumarłych lecz nieżywych ocalałych");
        unit.afterEffects.Add(new MoveEffect(unit, Zone.one()));
        unit.afterEffects.Add(new AttackEffect(unit, Zone.frame(1)));
    }

    public List<GameObject> getWave(int level) {
        List<GameObject> wave = new List<GameObject>();
        for (int i = 0; i < 3; i++) {
            GameObject obj = Instantiate(basicEnemy, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
            BasicEnemy(obj.GetComponent<UnitBase>());
            wave.Add(obj);
        }
        
        return wave;
    }
}
