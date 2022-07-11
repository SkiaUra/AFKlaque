using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "State/BasicIdle")]
public class State_BasicHit : BaseState {

    Tween Tween;

    public override void EnterState(FighterSM _FighterSM) { // Do enter shit once
        _FighterSM.AnimatorController.SetTrigger("Hit");
    }

    public override void UpdateState(FighterSM _FighterSM) { // Do things

    }

    public override void ExitState(FighterSM _FighterSM) { // End things if needed
        _FighterSM.MakeNewDecision();
    }

    public Tween MoveToPosition(FighterSM _FighterSM, Vector3 _EndPoint) {
        Vector3 PosXZ = new Vector3(_EndPoint.x, 0f, _EndPoint.z);
        // temps = dist / vitesse
        float MoveTime = Mathf.Abs(Vector3.Distance(_FighterSM.transform.position, PosXZ) / _FighterSM.FighterEntity.ComputedMoveSpeed);
        return Tween = _FighterSM.transform.DOMove(PosXZ, MoveTime);
    }
}