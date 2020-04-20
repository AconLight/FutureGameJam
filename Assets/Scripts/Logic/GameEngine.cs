using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameEngine : MonoBehaviour
{
    public GameState state;
    public GameObject gridManagerPrefab;
    public GameObject enemyFactoryPrefab;
    public GameObject buildingFactoryPrefab;
    public AudioMenager audioMenagerPrefab;
    private AudioMenager audioMenager;
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
            audioMenager.initAudio("menu");
        }
        if (ctr == 10) {
            spawnMain();
            spawnNextWave();
        }
        if (ctr == 20) {
            stateManager.setState(GameState.BATTLETURN);
        }
        ctr++;
    }

    public void performBeforeEffects() {
        foreach(GameObject unit in allUnits) {
            unit.GetComponent<UnitBase>().performBeforeEffects();
        }
    }

    public void performAfterEffects() {
        foreach(GameObject unit in allUnits) {
            unit.GetComponent<UnitBase>().performAfterEffects();
        }
    }

    public void detectUnits()
    {
        Debug.Log("detectUnits");
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
                }
            }
        }
        Debug.Log(allUnits.Count);

    }

    public void sortUnits() {
        // allUnits.Sort((GameObject a, GameObject b) => 
        //     a.GetComponent<UnitBase>().unitCounters["iniciative"] - 
        //     b.GetComponent<UnitBase>().unitCounters["iniciative"]
        // );
    }

    public void spawnOne() {
        if (nextWave.Count > 0 && gridManager.GetComponent<GridScript>().spawnEnemy(nextWave[0])) {
            nextWave.RemoveAt(0);
            Debug.Log("spawnOne");
        } 
    }

    public void spawnNextWave() {
        nextWave.AddRange(enemyFactory.GetComponent<EnemyFactory>().getWave(0));
    }

    public void spawnMain() {
        gridManager.GetComponent<GridScript>().spawnMain(buildingFactory.GetComponent<BuildingsFactory>().getMain());
    }
}
