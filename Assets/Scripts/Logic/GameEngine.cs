using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { START, PLAYER1TURN, PLAYER2TURN, BATTLETURN, LOST }
public class GameEngine : MonoBehaviour
{
    public GameState state;
    public GameObject gridManagerScript;
    private List<GameObject> allUnits;
    // Start is called before the first frame update
    void Start()
    {
        state = GameState.START;
    }

    void detectUnits()
    {
         
    }
}
