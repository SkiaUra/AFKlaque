using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "State/Movement/MoveAwayEnemy")]
public class State_MoveAwayFromEnemy : State_BasicMove {

    private Tween Tween;

    public override void EnterState(FighterSM _FighterSM) { // Do enter shit once
        Vector3 pos = _ToolboxMovement.GetPositionAwayFromEnemy(_FighterSM, _FighterSM.FighterEntity.ComputedMoveRange);
        Tween = this._ToolboxMovement.MoveToPosition(_FighterSM, pos);
        _FighterSM.FighterEntity.ComputedMoveDelay = _FighterSM.FighterEntity.FighterTemplate.MoveDelay;
    }

    public override void UpdateState(FighterSM _FighterSM) { // Do things
        if (!Tween.IsPlaying()) {
            _FighterSM.AnimatorController.SetBool("Walk", false);
            ExitState(_FighterSM);
        }
    }

    public override void ExitState(FighterSM _FighterSM) { // End things if needed
        _FighterSM.MakeNewDecision();
    }
}