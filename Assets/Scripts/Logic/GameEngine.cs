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
        sapwnNextWave();
        UnityEngine.Debug.Log("nextWaveCount: " + nextWave.Count);
    }

    void Update(){
        if(counter % 250 == 0){ // once for five
            // players spawn buildings
        }
        if(counter % 50 == 10) { // once
            spawnOne();
            detectUnits();
            computeEarthCounters();
            computeUnitCounters();
            sortUnits();
            allMakeTurn();
        }
        counter ++;
    }

    private void computeEarthCounters() {

    }

    private void computeUnitCounters() {
        
    }

    void detectUnits()
    {
        allUnits.Clear();
        foreach( var x in gridManager.GetComponent<GridScript>().GridElements)
        {
            //Debug.Log(x.ToString() + " DUPAX");
            foreach( var y in x)
            {
                var gridElement = y.GetComponent<GridElement>();
                //Debug.Log(Unit.x + ", " + Unit.z + " dupa");
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

    private void allMakeTurn() {
        for (int i = 0; i < allUnits.Count; i++) { // not foreach -> order matters
            allUnits[i].GetComponent<UnitBase>().makeTurn();
        }
    }

    private void spawnOne() {
        if (nextWave.Count > 0 && gridManager.GetComponent<GridScript>().spawnEnemy(nextWave[0])) {
            nextWave.RemoveAt(0);
        } 
    }

    public void sapwnNextWave() {
        nextWave.AddRange(unitLoader.GetComponent<UnitLoader>().getWave(0));
    }
}
