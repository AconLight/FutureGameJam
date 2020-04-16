using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { START, PLAYER1TURN, PLAYER2TURN, BATTLETURN, LOST }
public class GameEngine : MonoBehaviour
{
    public GameState state;
    public GameObject gridManagerPrefab;
    public GameObject unitLoader;
    private GameObject gridManager; 
    private List<UnitBase> allUnits;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        state = GameState.START;
        gridManager = Instantiate(gridManagerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        sapwnNextWave();
        UnityEngine.Debug.Log("nextWaveCount: " + nextWave.Count);
    }

    void detectUnits()
    {
        foreach( var x in gridManager.GetComponent<GridScript>().GridElements)
        {
            //Debug.Log(x.ToString() + " DUPAX");
            foreach( var y in x)
            {
                var Unit = y.GetComponent<GridElement>();
                //Debug.Log(Unit.x + ", " + Unit.z + " dupa");
            }
        }
    }
    void Update(){
        if(counter % 50 == 0){
            detectUnits();
        }
        if(counter % 50 == 10){
            if (gridManager.GetComponent<GridScript>().spawnEnemy(nextWave[0])) {
                nextWave.RemoveAt(0);
            }
        }
        if(counter % 50 == 20){
            // all units makes turn
        }
        counter ++;
        
    }

    private List<GameObject> nextWave = new List<GameObject>();
    public void sapwnNextWave() {
        nextWave.AddRange(unitLoader.GetComponent<UnitLoader>().getWave(0));
    }
}
