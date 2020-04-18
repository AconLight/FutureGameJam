using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { START, PLAYER1TURN, PLAYER2TURN, BATTLETURN, LOST }
public class GameEngine : MonoBehaviour
{
    public GameState state;
    public GameObject gridManagerPrefab;
    public GameObject unitLoaderPrefab;
    public GameObject audioMenagerPrefab;
    private GameObject audioMenager;
    private GameObject unitLoader;
    private GameObject gridManager; 
    private List<GameObject> allUnits;
    private List<GameObject> nextWave = new List<GameObject>();
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        allUnits = new List<GameObject>();
        state = GameState.START;
        gridManager = Instantiate(gridManagerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        unitLoader = Instantiate(unitLoaderPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        audioMenager = Instantiate(audioMenagerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        //spawnMain();
        spawnNextWave();
        UnityEngine.Debug.Log("nextWaveCount: " + nextWave.Count);
    }

    public delegate void Del();
    public static List<Del> dels = new List<Del>();

    void Update(){
        //TODO wiktor plz zrób porządnie, żeby się czekało na ruch gracza przy budowaniu i żeby tura walki/chodzenia trwała x milisekund np 1000
        if(counter % 250 == 0){ // once for five
            // players spawn buildings
        }
        if(counter % 50 == 10) { // once
            spawnOne();
        }
        if(counter % 50 == 15) {
            if (dels.Count > 0) {
                dels[0]();
                dels.RemoveAt(0);
            }
        }
        if(counter % 50 == 20) { // once
            detectUnits();
            performBeforeEffects();
            sortUnits();
            performAfterEffects();
        }
        counter ++;
    }

    private void performBeforeEffects() {
        foreach(GameObject unit in allUnits) {
            unit.GetComponent<UnitBase>().performBeforeEffects();
        }
    }

    private void performAfterEffects() {
        foreach(GameObject unit in allUnits) {
            unit.GetComponent<UnitBase>().performAfterEffects();
        }
    }

    void detectUnits()
    {
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
    }

    private void sortUnits() {
        allUnits.Sort((GameObject a, GameObject b) => 
            a.GetComponent<UnitBase>().unitCounters["iniciative"] - 
            b.GetComponent<UnitBase>().unitCounters["iniciative"]
        );
    }

    private void spawnOne() {
        if (nextWave.Count > 0 && gridManager.GetComponent<GridScript>().spawnEnemy(nextWave[0])) {
            nextWave.RemoveAt(0);
        } 
    }

    public void spawnNextWave() {
        nextWave.AddRange(unitLoader.GetComponent<UnitLoader>().getWave(0));
    }

    public void spawnMain() {
        gridManager.GetComponent<GridScript>().spawnMain(unitLoader.GetComponent<UnitLoader>().getMain());
    }
}
