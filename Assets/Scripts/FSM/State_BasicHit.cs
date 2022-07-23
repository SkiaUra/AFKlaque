using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Attackdetails {

}

[CreateAssetMenu(menuName = "State/BasicHit")]
public class State_BasicHit : BaseState {

    public Attackdetails Attackdetails;
    private Tween _Tween;

    public override void EnterState(FighterSM FighterSM) { // Do enter shit once
        FighterSM.AnimatorController.SetBool("Hit", true);
        Vector3 pos = this._ToolboxMovement.GetPositionPushBack(FighterSM, 2f);
        _Tween = this._ToolboxMovement.MoveToPosition(FighterSM, pos);
        FighterSM.FighterEntity.isCooldownFreezed = true;
    }

    public override void UpdateState(FighterSM FighterSM) { // Do things
        if (!_Tween.IsPlaying()) {
            ExitState(FighterSM, true);
        }
    }

    public override void ExitState(FighterSM FighterSM, bool startNewDecision) { // End things if needed
        FighterSM.AnimatorController.SetBool("Hit", false);
        FighterSM.FighterEntity.isCooldownFreezed = false;
        if (startNewDecision) FighterSM.MakeNewDecision();
    }
}