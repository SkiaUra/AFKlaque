using UnityEngine;

[CreateAssetMenu(fileName = "State/BasicIdle")]
public class State_BasicIdle : BaseState {

    public override void EnterState(FighterSM _FighterSM) { // Do enter shit once

    }

    public override void UpdateState(FighterSM _FighterSM) { // Do things
        UpdateCycle(_FighterSM);
        ExitState(_FighterSM);
    }

    public override void ExitState(FighterSM _FighterSM) { // End things if needed
        _FighterSM.MakeNewDecision();
    }

    public void UpdateCycle(FighterSM _FighterSM) {
        _FighterSM.FighterEntity.ComputedMoveDelay -= Time.deltaTime;
        _FighterSM.FighterEntity.MainWeaponCountdown -= Time.deltaTime;
    }
}