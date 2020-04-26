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
        Debug.Log(missionId);
        switch (missionId) {
            case 0: {
                switch (waveId) {
                    case 0: {
                        var tempWave = makeWave(1,0,0,0,wave);
                        break;
                    }
                    case 1: {
                        var tempWave = makeWave(1,0,0,0,wave);
                        break;
                    }
                    case 2: {
                        var tempWave = makeWave(2,1,0,0,wave);
                        break;
                    }
                    case 3: {
                        var tempWave = makeWave(2,1,0,0,wave);
                        break;
                    }
                }
                break;
            }
            case 1: {
                switch (waveId) {
                    case 0: {
                        var tempWave = makeWave(2,0,0,0,wave);
                        break;
                    }
                    case 1: {
                        var tempWave = makeWave(2,1,0,0,wave);
                        break;
                    }
                    case 2: {
                        var tempWave = makeWave(3,1,1,0,wave);
                        break;
                    }
                    case 3: {
                        var tempWave = makeWave(3,2,1,0,wave);
                        break;
                    }
                }
                break;
            }
            case 2: {
                switch (waveId) {
                    case 0: {
                        var tempWave = makeWave(2,2,1,0,wave);
                        break;
                    }
                    case 1: {
                        var tempWave = makeWave(2,3,2,0,wave);
                        break;
                    }
                    case 2: {
                        var tempWave = makeWave(2,3,2,0,wave);
                        break;
                    }
                    case 3: {
                        var tempWave = makeWave(3,3,3,1,wave);
                        break;
                    }
                }
                break;
            }
            case 3: {
                switch (waveId) {
                    case 0: {
                        var tempWave = makeWave(5,2,1,0,wave);
                        break;
                    }
                    case 1: {
                        var tempWave = makeWave(5,3,2,0,wave);
                        break;
                    }
                    case 2: {
                        var tempWave = makeWave(5,4,3,1,wave);
                        break;
                    }
                    case 3: {
                        var tempWave = makeWave(5,4,2,2,wave);
                        break;
                    }
                }
                break;
            }
        }
        return wave;
    }

    public List<GameObject> makeWave(int zomie, int bers, int golomp, int boss, List<GameObject> wave){
    for (int i = 0; i < zomie; i++) {
            GameObject temp = Instantiate(basicEnemyPrefab, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
            BasicEnemy(temp.GetComponent<UnitBase>());
            wave.Add(temp);
    }
    for (int i = 0; i < bers; i++) {
        GameObject temp = Instantiate(ZombieBerserPrefab, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
        BerserkEnemy(temp.GetComponent<UnitBase>());
        wave.Add(temp);
    }
    for (int i = 0; i < golomp; i++) {
        GameObject temp = Instantiate(GolompPrefab, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
        GolompEnemy(temp.GetComponent<UnitBase>());
        wave.Add(temp);
    }
    for (int i = 0; i < boss; i++) {
        GameObject temp = Instantiate(ZombieBossPrefab, new Vector3(-99999, 0, 0), Quaternion.identity) as GameObject;
        BossEnemy(temp.GetComponent<UnitBase>());
        wave.Add(temp);
    }
    return wave;
}

}

