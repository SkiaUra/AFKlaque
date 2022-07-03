using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "State/Movement/MoveTowardEnemy")]
public class State_MoveTowardEnemy : BaseState {

    Tween Tween;

    public override void EnterState(FighterSM _FighterSM) { // Do enter shit once
        _FighterSM.AnimatorController.SetTrigger("Walk");
        Vector3 pos = SeekValidedestination(_FighterSM, _FighterSM.FighterEntity.ComputedMoveRange);
        Tween = MoveToPosition(_FighterSM, pos);
        _FighterSM.FighterEntity.ComputedMoveDelay = _FighterSM.FighterEntity.FighterTemplate.MoveDelay;
    }

    public override void UpdateState(FighterSM _FighterSM) { // Do things
        if (!Tween.IsPlaying()) {
            ExitState(_FighterSM);
        }
    }

    public override void ExitState(FighterSM _FighterSM) { // End things if needed

        _FighterSM.MakeNewDecision();
    }

    // CUSTOM METHODS //

    public Tween MoveToPosition(FighterSM _FighterSM, Vector3 _EndPoint) {
        Vector3 PosXZ = new Vector3(_EndPoint.x, 0f, _EndPoint.z);
        // temps = dist / vitesse
        float MoveTime = Mathf.Abs(Vector3.Distance(_FighterSM.transform.position, PosXZ) / _FighterSM.FighterEntity.ComputedMoveSpeed);
        return Tween = _FighterSM.transform.DOMove(PosXZ, MoveTime);
    }

    Vector3 SeekValidedestination(FighterSM _FighterSM, float radiusMax) {
        FighterEntity e = _FighterSM.FighterEntity;

        Vector3 TowardEnemy = Vector3.Normalize(e.EnemyFighter.transform.position - e.transform.position);

        // No overshoot
        float dist = Vector3.Distance(e.transform.position, e.EnemyFighter.transform.position);
        if (dist >= e.ComputedMoveRange) {
            TowardEnemy = TowardEnemy * e.ComputedMoveRange;
        } else {
            TowardEnemy = TowardEnemy * (dist * 0.5f);
        }

        Vector3 FinalPos = _FighterSM.transform.position + TowardEnemy;
        _FighterSM.DebugTargetMovement = FinalPos;
        return FinalPos;
    }
}
