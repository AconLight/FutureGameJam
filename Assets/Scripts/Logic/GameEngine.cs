using System;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameEngine : MonoBehaviour
{
    public GameObject canvas;
    public GameState state;
    public GameObject gridManagerPrefab;
    public GameObject enemyFactoryPrefab;
    public GameObject buildingFactoryPrefab;
    public GameObject audioMenagerPrefab;
    private GameObject audioMenager;
    private GameObject enemyFactory, buildingFactory;
    private GameObject gridManager; 

    private StateManager stateManager;
    private List<GameObject> allUnits;
    private List<GameObject> nextWave = new List<GameObject>();
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        allUnits = new List<GameObject>();
        stateManager = new StateManager(this);
        gridManager = Instantiate(gridManagerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        enemyFactory = Instantiate(enemyFactoryPrefab, new Vector3(-9999999, 0, 0), Quaternion.identity);
        buildingFactory = Instantiate(buildingFactoryPrefab, new Vector3(-9999999, 0, 0), Quaternion.identity);
        audioMenager = Instantiate(audioMenagerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    int ctr = 0;
    void Update() {
        if(ctr == 5)
        {
           audioMenager.GetComponent<AudioMenager>().initAudio("menu");
        }
        if (ctr == 10) {
            spawnMain();
            spawnNextWave();
            buildingFactory.GetComponent<BuildingsFactory>().createDeck();
            buildingFactory.GetComponent<BuildingsFactory>().createHand();
        }
        if (ctr == 20) {
            stateManager.setState(GameState.PLAYER1TURN);
        }
        if (ctr > 50 && ctr%60 == 0) {
            stateManager.update();
        }
        ctr++;
    }

    public void endTurn() {
        stateManager.setState(GameState.BATTLETURN);
    }

    public void startBattle() {
        foreach(GameObject unit in allUnits) {
            unit.GetComponent<UnitBase>().unitCounters["ap"] = unit.GetComponent<UnitBase>().unitCounters["apMax"];
        }
    }

    public void performBeforeEffects() {
        foreach(GameObject unit in allUnits) {
            unit.GetComponent<UnitBase>().performBeforeEffects();
        }
    }

    public Boolean performAfterEffects() {
        //Debug.Log("perform after effects");
        Boolean isEnd = true;
        foreach(GameObject unit in allUnits) {
            if (unit.GetComponent<UnitBase>().unitCounters["ap"] > 0 || unit.GetComponent<UnitBase>().unitCounters["isEnemy"] == 0) {
                unit.GetComponent<UnitBase>().performAfterEffects();
                unit.GetComponent<UnitBase>().unitCounters["ap"]--;
                if (unit.GetComponent<UnitBase>().unitCounters["isEnemy"] == 1) {
                    isEnd = false;
                }
            }
        }
        return isEnd;
    }

    public void detectUnits()
    {
        //Debug.Log("detectUnits");
        allUnits.Clear();
        foreach( var x in gridManager.GetComponent<GridScript>().GridElements)
        {
            foreach( var y in x)
            {
                var gridElement = y.GetComponent<GridElement>();
                List<string> keys = new List<string>(gridElement.earthCounters.Keys);
                foreach(string key in keys) {
                    gridElement.earthCounters[key] = 0;
                }
                if(gridElement.unit != null)
                {
                    allUnits.Add(gridElement.unit);
                    
                    //Debug.Log("detedted one, after effects size: " + gridElement.unit.GetComponent<UnitBase>().afterEffects.Count);
                }
            }
        }
        //Debug.Log(allUnits.Count);

    }

    public void sortUnits() {
        allUnits.Sort((GameObject a, GameObject b) => 
            a.GetComponent<UnitBase>().unitCounters["iniciative"] - 
            b.GetComponent<UnitBase>().unitCounters["iniciative"]
        );
    }

    public Boolean spawnOne() {
        if (nextWave.Count > 0 && gridManager.GetComponent<GridScript>().spawnEnemy(nextWave[0])) {
            nextWave.RemoveAt(0);
            //Debug.Log("spawnOne");
            return true;
        } 
        return false;
    }

    public void spawnNextWave() {
        nextWave.AddRange(enemyFactory.GetComponent<EnemyFactory>().getWave(0));
    }

    public void spawnMain() {
        gridManager.GetComponent<GridScript>().spawnMain(buildingFactory.GetComponent<BuildingsFactory>().getMain());
    }

    public void spawn(GameObject unit, GameObject gridElement) {
        gridElement.GetComponent<GridElement>().spawnUnit(unit);
    }

    public void spawnById(int unitId, int gridElementX, int gridElementZ) {
        // TODO
    }
}
