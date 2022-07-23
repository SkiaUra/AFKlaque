using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "State/Movement/MoveAwayEnemy")]
public class State_MoveAwayFromEnemy : State_BasicMove {

    private Tween _Tween;

    public override void EnterState(FighterSM FighterSM) { // Do enter shit once
        FighterSM.AnimatorController.SetBool("Walk", true);
        Vector3 pos = _ToolboxMovement.GetPositionAwayFromEnemy(FighterSM, FighterSM.FighterEntity.ComputedMoveRange);
        _Tween = this._ToolboxMovement.MoveToPosition(FighterSM, pos);
        FighterSM.FighterEntity.ComputedMoveDelay = FighterSM.FighterEntity.FighterTemplate.MoveDelay;
    }

    public override void UpdateState(FighterSM FighterSM) { // Do things
        if (!_Tween.IsPlaying()) {
            ExitState(FighterSM, true);
        }
    }

    public override void ExitState(FighterSM FighterSM, bool startNewDecision) { // End things if needed
        if (_Tween.IsPlaying()) {
            _ToolboxMovement.StopMovement(_Tween);
        }
        FighterSM.AnimatorController.SetBool("Walk", false);
        if (startNewDecision) FighterSM.MakeNewDecision();
    }
}