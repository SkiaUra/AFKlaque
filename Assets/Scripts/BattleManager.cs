using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class BattleManager : MonoBehaviour {

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
        NewBattle(TestFighterA, TestFighterB);
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

    }

    public void SetGameSpeed(float _Speed) {
        Time.timeScale = _Speed;
    }

    void OnDrawGizmos() {
        UnityEditor.Handles.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(ArenaCenter, Vector3.up, ArenaRadius);
    }

}