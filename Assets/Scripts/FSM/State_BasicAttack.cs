using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "State/BasicAttack")]
public class State_BasicAttack : BaseState {

    Tween Tween;

    public override void EnterState(FighterSM _FighterSM) { // Do enter shit once

    }

    public override void UpdateState(FighterSM _FighterSM) { // Do things
        Debug.LogWarning("!!! ATTACK !!!");
        float dist = Vector3.Distance(_FighterSM.FighterEntity.transform.position, _FighterSM.FighterEntity.EnemyFighter.transform.position);
        if (Mathf.Abs(dist - _FighterSM.FighterEntity.MainWeapon.AttackRange) <= 0.1f) {
            // HIT
            _FighterSM.FighterEntity.EnemyFighter.ComputedCurrentHealth -= _FighterSM.FighterEntity.MainWeaponDamage;
            Debug.Log("=> Attack Hit !!");
        } else {
            // FAIL
            Debug.Log("=> Attack Fail !!");
        }
        ExitState(_FighterSM);
    }

    public override void ExitState(FighterSM _FighterSM) { // End things if needed
        _FighterSM.MakeNewDecision();
    }

    public Vector3 ClosestPositionToTarget(FighterSM _FighterSM) {
        Vector3 A = _FighterSM.FighterEntity.transform.position;
        Vector3 B = _FighterSM.FighterEntity.EnemyFighter.transform.position;
        Vector3 AB = Vector3.Normalize(A - B);
        return B + AB * _FighterSM.FighterEntity.MainWeapon.AttackRange;
    }
}