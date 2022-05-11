using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;

public class BattleManager : MonoBehaviour {

    public GUIManager GUIManager;
    public GameObject FighterPrefab;

    public Rect Area = new Rect();
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

        FighterA = Instantiate(FighterPrefab, StartingPosA).GetComponent<FighterEntity>();
        FighterB = Instantiate(FighterPrefab, StartingPosB).GetComponent<FighterEntity>();
        FighterA.BattleManager = this;
        FighterB.BattleManager = this;
        FighterA.EnemyFighter = FighterB;
        FighterB.EnemyFighter = FighterA;
        FighterA.SetupEntity(_FighterA);
        FighterB.SetupEntity(_FighterB);
        GUIManager.PlayerHealthBar.SetupHealthBar(FighterA);
        GUIManager.EnemyHealthBar.SetupHealthBar(FighterB);

    }

    void OnDrawGizmos() {
        UnityEditor.Handles.color = Color.white;
        UnityEditor.Handles.DrawWireCube(Vector3.zero, new Vector3(Area.width, 0f, Area.height));
    }

}