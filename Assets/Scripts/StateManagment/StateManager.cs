using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { PLAYER1TURN, PLAYER2TURN, BATTLETURN, LOST }
public class StateManager
{
    GameState gameState;
    GameEngine gameEngine;
    public StateManager(GameEngine gameEngine) {
        this.gameState = GameState.PLAYER2TURN;
        this.gameEngine = gameEngine;
    }

    public void setState(GameState gameState) {
        this.gameState = gameState;
        switch(this.gameState) {
            case GameState.PLAYER1TURN: {

                break;
            }
            case GameState.PLAYER2TURN: {

                break;
            }
            case GameState.BATTLETURN: {
                for (int i = 0; i < 2; i++) {
                    gameEngine.spawnOne();
                    gameEngine.detectUnits();
                    gameEngine.performBeforeEffects();
                    gameEngine.sortUnits();
                    gameEngine.performAfterEffects();
                }
                break;
            }
        }
    }
}
