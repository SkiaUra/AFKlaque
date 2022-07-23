using UnityEngine;

[CreateAssetMenu(menuName = "State/BasicIdle")]
public class State_BasicIdle : BaseState {

    public override void EnterState(FighterSM FighterSM) { // Do enter shit once
        FighterSM.AnimatorController.SetBool("Idle", true);
    }

    public override void UpdateState(FighterSM FighterSM) { // Do things
        UpdateCycle(FighterSM);
        ExitState(FighterSM, true);
    }

    public override void ExitState(FighterSM FighterSM, bool startNewDecision) { // End things if needed
        if (startNewDecision) FighterSM.MakeNewDecision();
    }

    public void UpdateCycle(FighterSM FighterSM) {
        if (!FighterSM.FighterEntity.isCooldownFreezed) {
            FighterSM.FighterEntity.ComputedMoveDelay -= Time.deltaTime;
            FighterSM.FighterEntity.MainWeaponCountdown -= Time.deltaTime;
        }
    }
}