using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ToolboxMovement {

    public Tween MoveToPosition(FighterSM FighterSM, Vector3 _EndPoint) {
        _EndPoint = new Vector3(_EndPoint.x, 0f, _EndPoint.z);
        FighterSM.DebugTargetMovement = _EndPoint;
        // temps = dist / vitesse
        float dist = Vector3.Distance(FighterSM.transform.position, _EndPoint);
        float speed = FighterSM.FighterEntity.ComputedMoveSpeed;
        float moveTime = Mathf.Abs(dist / speed);
        FighterSM.AnimatorController.SetBool("Walk", true);
        return FighterSM.transform.DOMove(_EndPoint, moveTime).SetEase(Ease.InOutSine);
    }

    public Vector3 GetRandomPositionAroundMe(FighterSM _FighterSM, float radiusMax) {
        FighterEntity e = _FighterSM.FighterEntity;

        Vector3 randomDirection = Random.insideUnitSphere * radiusMax; // get direction
        Vector3 PickedPosition = _FighterSM.transform.position + randomDirection;
        Vector3 _ArenaCenter = e.BattleManager.ArenaCenter;
        float _ArenaSize = e.BattleManager.ArenaRadius;
        Vector3 FinalPos = PickedPosition;

        // Is picked position inside arena bounds ? => TODO sortir ça et en faire une methode
        bool isValidPosition = Vector3.Distance(PickedPosition, _ArenaCenter) < _ArenaSize;
        if (!isValidPosition) {
            Vector3 TowardArenaCenter = PickedPosition - _ArenaCenter;
            FinalPos = Vector3.Normalize(TowardArenaCenter) * _ArenaSize;
        }
        return FinalPos;
    }

    public Vector3 GetPositionAwayFromEnemy(FighterSM _FighterSM, float radiusMax) {
        FighterEntity e = _FighterSM.FighterEntity;

        Vector3 AwayFromEnemy = Vector3.Normalize(e.transform.position - e.EnemyFighter.transform.position);
        Vector3 PickedPosition = _FighterSM.transform.position + AwayFromEnemy;

        // Not outside Arena
        Vector3 _ArenaCenter = _FighterSM.FighterEntity.BattleManager.ArenaCenter;
        float _ArenaSize = _FighterSM.FighterEntity.BattleManager.ArenaRadius;
        float dist = Vector3.Distance(PickedPosition, _ArenaCenter);
        Vector3 FinalPos = PickedPosition;

        if (dist > _ArenaSize) {
            Vector3 TowardArenaCenter = PickedPosition - _ArenaCenter;
            FinalPos = Vector3.Normalize(TowardArenaCenter) * _ArenaSize;
        }
        return FinalPos;
    }

    public Vector3 GetPositionTowardEnemy(FighterSM _FighterSM, float radiusMax) {
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
        return FinalPos;
    }

    public Vector3 ClosestPositionToTarget(FighterSM _FighterSM) {
        Vector3 A = _FighterSM.FighterEntity.transform.position;
        Vector3 B = _FighterSM.FighterEntity.EnemyFighter.transform.position;
        Vector3 AB = Vector3.Normalize(A - B);
        return B + AB * _FighterSM.FighterEntity.MainWeapon.AttackRange;
    }
}
