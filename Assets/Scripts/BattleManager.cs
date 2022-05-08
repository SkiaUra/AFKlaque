using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;

public class BattleManager : MonoBehaviour {
    public GameObject FighterPrefab;

    public Rect Area = new Rect();
    public FighterEntity Entity1;
    public FighterEntity Entity2;


    [Button("Start Battle")]
    public void NewBattle(FighterTemplate _FighterA, FighterTemplate _FighterB) { // add seed
        Debug.LogWarning("<<< New battle >>>");
        // instantier les fighters
        // setup fighters A & B
        // Passer les fighters en fight state
    }

    void OnDrawGizmos() {
        UnityEditor.Handles.color = Color.white;
        UnityEditor.Handles.DrawWireCube(Vector3.zero, new Vector3(Area.width, 0f, Area.height));
    }

}