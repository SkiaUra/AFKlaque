using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "State/Movement/MoveAwayEnemy")]
public class State_MoveAwayFromEnemy : BaseState {

    Tween Tween;

    public override void EnterState(FighterSM _FighterSM) { // Do enter shit once
        _FighterSM.AnimatorController.SetBool("Walk", true);
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
        _FighterSM.AnimatorController.SetBool("Walk", false);
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

        Vector3 AwayFromEnemy = Vector3.Normalize(e.transform.position - e.EnemyFighter.transform.position);

        Vector3 PickedPosition = _FighterSM.transform.position + AwayFromEnemy;

        // Not outside Arena
        Vector3 _ArenaCenter = _FighterSM.FighterEntity.BattleManager.ArenaCenter;
        float _ArenaSize = _FighterSM.FighterEntity.BattleManager.ArenaRadius;
        float dist = Vector3.Distance(PickedPosition, _ArenaCenter);
        Vector3 FinalPos = PickedPosition;

        if (dist < _ArenaSize) {
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
