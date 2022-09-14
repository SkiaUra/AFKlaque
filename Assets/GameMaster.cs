using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates {
    LOBBY,
    BATTLE
}

public class GameMaster : MonoBehaviour {
    public GameStates GameState;
    public BattleManager BattleManager;
    public GUIManager GuiManager;

    void Start() {
        SwitchToLobby();
    }

    void Update() {

    }

    public void SwitchToLobby() {
        BattleManager.BMState = BattleManager.BattleManagerStates.END;
        GameState = GameStates.LOBBY;
        GuiManager.DisplayLobbyGUI();
    }

    public void SwitchToBattle() {
        GameState = GameStates.BATTLE;
        GuiManager.DisplayBattleGUI();
        BattleManager.BMState = BattleManager.BattleManagerStates.INIT;
    }
}
