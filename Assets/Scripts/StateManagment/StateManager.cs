using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { PLAYER1TURN, PLAYER2TURN, BATTLETURN, LOST }
public class StateManager
{
    public GameState gameState;
    GameEngine gameEngine;
    public StateManager(GameEngine gameEngine) {
        this.gameState = GameState.PLAYER2TURN;
        this.gameEngine = gameEngine;
    }

    public int turns = 0;
    System.Random rand = new System.Random();
    public void update(int ctr) {
        switch(this.gameState) {
            case GameState.PLAYER1TURN: {

                break;
            }
            case GameState.PLAYER2TURN: {

                break;
            }
            case GameState.BATTLETURN: {
                gameEngine.spawnOne();
                gameEngine.detectUnits();
                gameEngine.performBeforeEffects();
                gameEngine.sortUnits();
                if (gameEngine.performAfterEffects(ctr-1)) {
                    if (!gameEngine.hasAnyEnemies && gameEngine.getWaves() == 5 && gameEngine.main || gameEngine.getWaves() == 2) {
                        gameEngine.gridManager.GetComponent<GridScript>().clear();
                        foreach (CardContent cc in gameEngine.canvas.GetComponentsInChildren<CardContent>()) {
                            cc.DestroyMe();
                        }
                        gameEngine.setMissionId(gameEngine.getMissionId()+1);
                        gameEngine.resetCtr();
                    } else {
                        setState(GameState.PLAYER1TURN);
                    }
                }
                
                break;
            }
        }
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
                gameEngine.startBattle();
                turns++;
                if (turns > 0 && turns % 4 == 0) {
                    gameEngine.spawnId = rand.Next(0, 2);
                    gameEngine.spawnNextWave();
                }
                break;
            }
        }
    }
}
