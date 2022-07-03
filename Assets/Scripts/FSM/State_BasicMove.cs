using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "State/Movement/RandomMovement")]
public class State_BasicMove : BaseState {

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
        _EndPoint = new Vector3(_EndPoint.x, 0f, _EndPoint.z);
        // temps = dist / vitesse
        float MoveTime = Mathf.Abs(Vector3.Distance(_FighterSM.transform.position, _EndPoint) / _FighterSM.FighterEntity.ComputedMoveSpeed);
        return Tween = _FighterSM.transform.DOMove(_EndPoint, MoveTime);
    }

    Vector3 SeekValidedestination(FighterSM _FighterSM, float radiusMax) {
        FighterEntity e = _FighterSM.FighterEntity;

        Vector3 randomDirection = Random.insideUnitSphere * radiusMax; // get direction

        Vector3 PickedPosition = _FighterSM.transform.position + randomDirection;

        Vector3 _ArenaCenter = e.BattleManager.ArenaCenter;
        float _ArenaSize = e.BattleManager.ArenaRadius;
        Vector3 FinalPos = PickedPosition;

        // Is picked position inside arena bounds ?
        if (Vector3.Distance(PickedPosition, _ArenaCenter) < _ArenaSize) {
            // Valid position, do nothing
        } else {
            // Wrong position
            Debug.Log("wrong position !");
            Vector3 TowardArenaCenter = PickedPosition - _ArenaCenter;
            FinalPos = Vector3.Normalize(TowardArenaCenter) * _ArenaSize;
        }

        _FighterSM.DebugTargetMovement = FinalPos;
        return FinalPos;
    }
}
