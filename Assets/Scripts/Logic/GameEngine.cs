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
                var gridElement = y.GetComponent<GridElement>();
                //Debug.Log(Unit.x + ", " + Unit.z + " dupa");
                if(gridElement.unit != null)
                {
                    allUnits.Add(gridElement.unit);
                }
            }
        }
    }
    void Update(){
        if(counter % 50 == 0){
            detectUnits();
            if(allUnits != null)
            {
                Debug.Log("Detected U: " + allUnits.ToString());
            }else
            {
                Debug.Log("KUWA");
            }
            
        }
        if(counter % 50 == 10){
            if (gridManager.GetComponent<GridScript>().spawnEnemy(nextWave[0])) {
                nextWave.RemoveAt(0);
            }
        }
        if(counter % 50 == 20){
            if(allUnits != null)
            {
                foreach(GameObject unit in allUnits)
                {
                    if(unit.GetComponent<UnitBase>())
                    {
                        unit.GetComponent<UnitBase>().Move(1,1);
                    }else
                    {
                        Debug.Log("Kurwa dopiero drugi dzień a tu już syf że ja pierdolę");
                    } 
                }
                
            }else
            {
                Debug.Log("Zdrowy to ty jesteś człowieku");
            }
            // all units makes turn
        }
        counter ++;
        
    }
    public void sapwnNextWave() {
        nextWave.AddRange(unitLoader.GetComponent<UnitLoader>().getWave(0));
    }
}
