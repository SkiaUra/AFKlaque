using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "State/BasicMove")]
public class State_BasicMove : BaseState {

    Tween Tween;

    public override void EnterState(FighterSM _FighterSM) { // Do enter shit once
        Vector3 pos = SeekValidedestination(_FighterSM, _FighterSM.FighterEntity.ComputedMoveRange);
        Tween = MoveToPosition(_FighterSM, pos);
    }

    public override void UpdateState(FighterSM _FighterSM) { // Do things
        if (!Tween.IsPlaying()) {
            ExitState(_FighterSM);
        }
    }

    public override void ExitState(FighterSM _FighterSM) { // End things if needed
        _FighterSM.FighterEntity.ComputedMoveDelay = _FighterSM.FighterEntity.FighterTemplate.MoveDelay;
        _FighterSM.MakeNewDecision();
    }

    // CUSTOM METHODS //

    public Tween MoveToPosition(FighterSM _FighterSM, Vector3 _EndPoint) {
        _EndPoint = new Vector3(_EndPoint.x, 0f, _EndPoint.z);
        // temps = dist / vitesse
        float MoveTime = Mathf.Abs(Vector3.Distance(_FighterSM.transform.position, _EndPoint) / _FighterSM.FighterEntity.ComputedMoveSpeed);
        return Tween = _FighterSM.transform.DOMove(_EndPoint, MoveTime).SetEase(Ease.InOutExpo);
    }

    Vector3 SeekValidedestination(FighterSM _FighterSM, float radiusMax) {
        Vector3 _ArenaCenter = _FighterSM.FighterEntity.BattleManager.ArenaCenter;
        float _ArenaSize = _FighterSM.FighterEntity.BattleManager.ArenaRadius;

        Vector3 randomDirection = Random.insideUnitSphere * radiusMax; // get direction

        Vector3 PickedPosition = _FighterSM.transform.position + randomDirection;
        PickedPosition = new Vector3(PickedPosition.x, 0, PickedPosition.z);

        // Is picked position inside arena bounds ?
        if (Vector3.Distance(PickedPosition, _ArenaCenter) < _ArenaSize) {
            // Valid position
            _FighterSM.MovePosition = PickedPosition;
        } else {
            // Wrong position
            Vector3 TowardArenaCenter = _ArenaCenter - PickedPosition;
            float OutRange = Vector3.Distance(PickedPosition, _ArenaCenter) - _ArenaSize;
            PickedPosition = PickedPosition + TowardArenaCenter * OutRange;
        }
        return PickedPosition;
    }
}
