using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory: MonoBehaviour
{
    public GameObject basicEnemyPrefab, GolompPrefab, ZombieBossPrefab, ZombieBerserPrefab;
    //public GameObject basicEnemy;

    public GameObject materialHolder;
    void Start() {
        //basicEnemy = Instantiate (basicEnemyPrefab, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity, this.transform);
    }

    int ctr = 0;
    void Update() {
        if (ctr == 5) {
            //BasicEnemy(basicEnemy.GetComponent<UnitBase>());
        }
        ctr++;
    }

    public void BasicEnemy(UnitBase unit) {
        //Debug.Log("enemy load");
        unit.unitCounters.Add("ap", 0);
        unit.unitCounters.Add("apMax", 2);
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 1);
        unit.audioMenager = Instantiate(unit._audioMenager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        unit.audioMenager.GetComponent<AudioMenager>().initAudio("enemy");
        unit.unitDescription.setCardDescription("Nieumarly alien", "Jeden z pierwszych odkrytych nieumarłych lecz nieżywych ocalałych");
        unit.afterEffects.Add(new MoveEffect(unit, Zone.one(), materialHolder));
        unit.afterEffects.Add(new AttackEffect(unit, Zone.frame(1), materialHolder));
    }
    public void GolompEnemy(UnitBase unit) {
        //Debug.Log("enemy load");
        unit.unitCounters.Add("ap", 0);
        unit.unitCounters.Add("apMax", 2);
        unit.unitCounters.Add("iniciative", 3);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 1);
        unit.audioMenager = Instantiate(unit._audioMenager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        unit.audioMenager.GetComponent<AudioMenager>().initAudio("enemy");
        unit.unitDescription.setCardDescription("Nieumarly pryskacz", "Szybki i do tego pluje");
        unit.afterEffects.Add(new MoveEffect(unit, Zone.one(), materialHolder));
        unit.afterEffects.Add(new AttackEffect(unit, Zone.frame(2), materialHolder));
    }
    public void BerserkEnemy(UnitBase unit) {
        //Debug.Log("enemy load");
        unit.unitCounters.Add("ap", 0);
        unit.unitCounters.Add("apMax", 2);
        unit.unitCounters.Add("iniciative", 2);
        unit.unitCounters.Add("hp", 3);
        unit.unitCounters.Add("speed", 2);
        unit.unitCounters.Add("maxSpeed", 2);
        unit.unitCounters.Add("isEnemy", 1);
        unit.audioMenager = Instantiate(unit._audioMenager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        unit.audioMenager.GetComponent<AudioMenager>().initAudio("enemy");
        unit.unitDescription.setCardDescription("Nieumarly woj", "Umarł jako pantofel ale po śmierci może znowu chwycić za topór");
        unit.afterEffects.Add(new MoveEffect(unit, Zone.one(), materialHolder));
        int[,] zone = 
        {
            {0,0,0,0,0},
            {0,2,2,2,0},
            {0,2,0,2,0},
            {0,2,2,2,0},
            {0,0,0,0,0},
        };
        unit.afterEffects.Add(new AttackEffect(unit, new Zone(zone), materialHolder));
    }
    public void BossEnemy(UnitBase unit) {
        //Debug.Log("enemy load");
        unit.unitCounters.Add("ap", 0);
        unit.unitCounters.Add("apMax", 1);
        unit.unitCounters.Add("iniciative", 1);
        unit.unitCounters.Add("hp", 30);
        unit.unitCounters.Add("speed", 1);
        unit.unitCounters.Add("maxSpeed", 1);
        unit.unitCounters.Add("isEnemy", 1);
        unit.audioMenager = Instantiate(unit._audioMenager, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        unit.audioMenager.GetComponent<AudioMenager>().initAudio("enemy");
        unit.unitDescription.setCardDescription("Don Zombie", "Tłusty, wolny i śmiertelnie niebezpieczny");
        unit.afterEffects.Add(new MoveEffect(unit, Zone.one(), materialHolder));
        int[,] zone = 
        {
            {0,0,0,0,0},
            {0,2,2,2,0},
            {0,2,0,2,0},
            {0,2,2,2,0},
            {0,0,0,0,0},
        };
        unit.afterEffects.Add(new AttackEffect(unit, new Zone(zone), materialHolder));
    }

    public List<GameObject> getWave(int waveId, int missionId) {
        List<GameObject> wave = new List<GameObject>();
        for (int i = 0; i < 3; i++) {
            GameObject obj = Instantiate(basicEnemyPrefab, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
            BasicEnemy(obj.GetComponent<UnitBase>());
            wave.Add(obj);
            //Debug.Log(obj.GetComponent<UnitBase>().afterEffects.Count);
        }
        
        return wave;
    }
}
