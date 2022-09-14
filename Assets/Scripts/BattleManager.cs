using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class BattleManager : MonoBehaviour {

    public enum BattleManagerStates {
        OFF = 0,
        INIT,
        BATTLE,
        END
    }
    public BattleManagerStates BMState = 0;

    [Header("Bindings")]
    public GameMaster GameMaster;
    public GUIManager GUIManager;
    public GameObject FighterPrefabA;
    public GameObject FighterPrefabB;

    public Vector3 ArenaCenter;
    public float ArenaRadius;
    public FighterEntity FighterA;
    public FighterEntity FighterB;

    public Transform StartingPosA;
    public Transform StartingPosB;

    public FighterTemplate TestFighterA;
    public FighterTemplate TestFighterB;

    void Start() {

    }

    void Update() {
        switch (BMState) {
            case BattleManagerStates.OFF:

                break;
            case BattleManagerStates.INIT:
                NewBattle(TestFighterA, TestFighterB);
                break;
            case BattleManagerStates.BATTLE:
                break;
            case BattleManagerStates.END:
                ClearBattle();
                break;
        }
    }

    [Button("Start Battle")]
    public void NewBattle(FighterTemplate _FighterA, FighterTemplate _FighterB) { // add seed
        Debug.LogWarning("<<< New battle >>>");

        FighterA = Instantiate(FighterPrefabA, StartingPosA).GetComponent<FighterEntity>();
        FighterB = Instantiate(FighterPrefabB, StartingPosB).GetComponent<FighterEntity>();
        FighterA.BattleManager = this;
        FighterB.BattleManager = this;
        FighterA.EnemyFighter = FighterB;
        FighterB.EnemyFighter = FighterA;
        FighterA.SetupEntity(_FighterA);
        FighterB.SetupEntity(_FighterB);
        GUIManager.PlayerHealthBar.SetupHealthBar(FighterA);
        GUIManager.EnemyHealthBar.SetupHealthBar(FighterB);

        BMState = BattleManagerStates.BATTLE;
    }

    public void ClearBattle() {
        if (FighterA) FighterA.KillEntity();
        if (FighterB) FighterB.KillEntity();
        FighterA = null;
        FighterB = null;
        BMState = BattleManagerStates.OFF;
    }

    public void SetGameSpeed(float _Speed) {
        Time.timeScale = _Speed;
    }

    void OnDrawGizmos() {
        UnityEditor.Handles.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(ArenaCenter, Vector3.up, ArenaRadius);
    }

}