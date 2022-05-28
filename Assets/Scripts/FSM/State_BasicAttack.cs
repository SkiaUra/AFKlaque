using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "State/Attack/BasicAttack")]
public class State_BasicAttack : BaseState {

    Tween Tween;

    public override void EnterState(FighterSM _FighterSM) { // Do enter shit once
        _FighterSM.FighterEntity.EnemyFighter.ComputedCurrentHealth -= _FighterSM.FighterEntity.MainWeaponDamage;
        _FighterSM.FighterEntity.PopupDamage.Show();
        _FighterSM.FighterEntity.MainWeaponCountdown = _FighterSM.FighterEntity.MainWeapon.AttackSpeed;
    }

    public override void UpdateState(FighterSM _FighterSM) { // Do things
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