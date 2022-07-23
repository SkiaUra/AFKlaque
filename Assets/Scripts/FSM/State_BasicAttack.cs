using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "State/Attack/BasicAttack")]
public class State_BasicAttack : BaseState {

    Tween Tween;

    public override void EnterState(FighterSM FighterSM) {
        FighterSM.AnimatorController.SetBool("Attack", true);
        // push away target
        FighterSM.FighterEntity.EnemyFighter.FighterSM.CancelState(FighterSM.FighterEntity.EnemyFighter.FighterSM.hit);
        // apply damage
        FighterSM.FighterEntity.EnemyFighter.ComputedCurrentHealth -= FighterSM.FighterEntity.MainWeaponDamage;
        // display popup
        FighterSM.FighterEntity.PopupDamage.Show();
        // reset cooldown
        FighterSM.FighterEntity.MainWeaponCountdown = FighterSM.FighterEntity.MainWeapon.AttackSpeed;
    }

    public override void UpdateState(FighterSM FighterSM) { // Do things
        ExitState(FighterSM, true);
    }

    public override void ExitState(FighterSM FighterSM, bool startNewDecision) { // End things if needed
        FighterSM.AnimatorController.SetBool("Attack", false);
        if (startNewDecision) FighterSM.MakeNewDecision();
    }
}