using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

[System.Serializable]
public class Action {
    [VerticalGroup("Action"), LabelWidth(50)]
    public string Name;
    [VerticalGroup("Action"), LabelWidth(50)]
    public BaseState ActionState;
    [VerticalGroup("Action"), LabelWidth(50), ReadOnly]
    public int ActionScore;

    [TableList(AlwaysExpanded = true)]
    public List<Scorer> Scorers;
}

[System.Serializable]
public class Scorer {
    public BATTLEDATA BattleData;
    [TableColumnWidth(90, false)] public Comparator Comparator;

    public BATTLEDATA CompBattleData;
    [ShowIf("@this.CompBattleData == BATTLEDATA.Float")] public float CompValue;
    [TableColumnWidth(50, false)] public int Score;
}

public enum Comparator {
    EQUAL = 0,
    INFERIOR = 1,
    SUPERIOR = 2
}

// [ExecuteInEditMode]
public class BrainManager : MonoBehaviour {
    public BattleDataManager BDM;

    [TableList]
    public List<Action> Actions = new List<Action>();


    void LateUpdate() {
        foreach (Action action in Actions) {
            UpdateAction(action);
        }
        // if (Input.GetMouseButtonDown(0)) PickAction();
    }



    public void UpdateAction(Action _Action) {
        _Action.ActionScore = 0;

        // Check all Scorer validity
        foreach (Scorer scorer in _Action.Scorers) {
            float ValueFromBDM = BDM.BattleDatas.First(t => t.DataType == scorer.BattleData).DataValue;
            switch (scorer.Comparator) {
                case Comparator.EQUAL:
                    if (scorer.CompBattleData == BATTLEDATA.Float) {
                        if (ValueFromBDM == scorer.CompValue) _Action.ActionScore += scorer.Score;
                    } else {
                        float v = BDM.BattleDatas.First(t => t.DataType == scorer.CompBattleData).DataValue;
                        if (ValueFromBDM == v) _Action.ActionScore += scorer.Score;
                    }
                    break;
                case Comparator.SUPERIOR:
                    if (scorer.CompBattleData == BATTLEDATA.Float) {
                        if (ValueFromBDM > scorer.CompValue) _Action.ActionScore += scorer.Score;
                    } else {
                        float v = BDM.BattleDatas.First(t => t.DataType == scorer.CompBattleData).DataValue;
                        if (ValueFromBDM > v) _Action.ActionScore += scorer.Score;
                    }
                    break;
                case Comparator.INFERIOR:
                    if (scorer.CompBattleData == BATTLEDATA.Float) {
                        if (ValueFromBDM < scorer.CompValue) _Action.ActionScore += scorer.Score;
                    } else {
                        float v = BDM.BattleDatas.First(t => t.DataType == scorer.CompBattleData).DataValue;
                        if (ValueFromBDM < v) _Action.ActionScore += scorer.Score;
                    }
                    break;
            }
        }
    }

    public BaseState PickAction() {
        // return the name of the action
        Action PickedAction = Actions.OrderByDescending(t => t.ActionScore).FirstOrDefault();
        // Debug.Log(PickedAction.Name + " score " + PickedAction.ActionScore);
        return PickedAction.ActionState;
    }
}
