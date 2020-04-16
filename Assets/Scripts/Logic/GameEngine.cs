using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { START, PLAYER1TURN, PLAYER2TURN, BATTLETURN, LOST }
public class GameEngine : MonoBehaviour
{
    public GameState state;
    public GameObject gridManagerScript;

    public GameObject unitLoader;
    private List<GameObject> allUnits;
    // Start is called before the first frame update
    void Start()
    {
        state = GameState.START;
    }

    void detectUnits()
    {
         
    }

    private List<GameObject> nextWave = new List<GameObject>();
    public void sapwnNextWave() {
        nextWave.AddRange(unitLoader.GetComponent<UnitLoader>().getWave(0));
    }
}
