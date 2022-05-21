using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

[System.Serializable]
public class Action {
    [VerticalGroup("Action"), LabelWidth(50)]
    public string Name;
    [VerticalGroup("Action"), LabelWidth(50), ReadOnly]
    public int ActionScore;

    [TableList(AlwaysExpanded = true)]
    public List<Scorer> Scorers;
}

[System.Serializable]
public class Scorer {
    public BATTLEDATA BattleData;
    [TableColumnWidth(90, false)] public Comparator Comparator;
    [TableColumnWidth(80, false)] public float ComparedValue;
    [TableColumnWidth(50, false)] public int Score;
}

public enum Comparator {
    EQUAL = 0,
    INFERIOR = 1,
    SUPERIOR = 2
}

[ExecuteInEditMode]
public class BrainManager : MonoBehaviour {
    public BattleDataManager BDM;

    [TableList]
    public List<Action> Actions = new List<Action>();


    void LateUpdate() {
        foreach (Action action in Actions) {
            UpdateAction(action);
        }
        if (Input.GetMouseButtonDown(0)) PickAction();
    }



    public void UpdateAction(Action _Action) {
        _Action.ActionScore = 0;

        // Check all Scorer validity
        foreach (Scorer scorer in _Action.Scorers) {
            float ValueFromBDM = BDM.BattleDatas.First(t => t.DataType == scorer.BattleData).DataValue;
            switch (scorer.Comparator) {
                case Comparator.EQUAL:
                    if (ValueFromBDM == scorer.ComparedValue) _Action.ActionScore += scorer.Score;
                    break;
                case Comparator.SUPERIOR:
                    if (ValueFromBDM > scorer.ComparedValue) _Action.ActionScore += scorer.Score;
                    break;
                case Comparator.INFERIOR:
                    if (ValueFromBDM < scorer.ComparedValue) _Action.ActionScore += scorer.Score;
                    break;
            }
        }
    }

    public void PickAction() {
        // return the name of the action
        string result = Actions.OrderByDescending(t => t.ActionScore).FirstOrDefault().Name;
        Debug.Log(result);
    }
}
