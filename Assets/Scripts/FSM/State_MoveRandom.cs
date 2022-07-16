using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "State/Movement/RandomMovement")]
public class State_MoveRandom : State_BasicMove {
    private Tween _Tween;

    public override void EnterState(FighterSM _FighterSM) { // Do enter shit once
        Vector3 pos = this._ToolboxMovement.GetRandomPositionAroundMe(_FighterSM, _FighterSM.FighterEntity.ComputedMoveRange);
        _Tween = this._ToolboxMovement.MoveToPosition(_FighterSM, pos);
        _FighterSM.FighterEntity.ComputedMoveDelay = _FighterSM.FighterEntity.FighterTemplate.MoveDelay;
    }

    public override void UpdateState(FighterSM _FighterSM) { // Do things
        Debug.Log("looping ?");
        if (!_Tween.IsPlaying()) {
            _FighterSM.AnimatorController.SetBool("Walk", false);
            ExitState(_FighterSM);
        }
    }

    public override void ExitState(FighterSM _FighterSM) { // End things if needed
        _FighterSM.MakeNewDecision();
    }
}
