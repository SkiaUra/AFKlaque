using UnityEngine;

[CreateAssetMenu(fileName = "State/BasicIdle")]
public class State_BasicIdle : BaseState {

    public float MinMoveRange;
    public float MaxMoveRange;
    public float MovementCooldown;
    protected float CurrentMovementCooldown;
    public Vector3 posCheck;

    public override void EnterState(FighterSM _FighterSM) { // Do enter shit once
        //Debug.LogWarning("Entering BasicIdle");
        CurrentMovementCooldown = MovementCooldown;
    }

    public override void UpdateState(FighterSM _FighterSM) { // Do things
        if (CurrentMovementCooldown <= 0) {
            SeekValidedestination(_FighterSM, MaxMoveRange);
            CurrentMovementCooldown = MovementCooldown;
            _FighterSM.SwitchState(_FighterSM.move);
        }
        CurrentMovementCooldown -= Time.deltaTime;
        MainWeaponCycle(_FighterSM);
    }

    public override void ExitState(FighterSM _FighterSM) { // End things if needed

    }

    public void MainWeaponCycle(FighterSM _FighterSM) {
        if (_FighterSM.FighterEntity.MainWeaponCountdown <= 0f) {
            _FighterSM.SwitchState(_FighterSM.attack);
            _FighterSM.FighterEntity.MainWeaponCountdown = _FighterSM.FighterEntity.MainWeapon.AttackSpeed;
        }
        _FighterSM.FighterEntity.MainWeaponCountdown -= Time.deltaTime;
    }

    void SeekValidedestination(FighterSM _FighterSM, float radiusMax) {
        Vector3 _ArenaCenter = _FighterSM.FighterEntity.BattleManager.ArenaCenter;
        float _ArenaSize = _FighterSM.FighterEntity.BattleManager.ArenaRadius;
        // Rect Bounds = _FighterSM.FighterEntity.BattleManager.Area;

        Vector3 randomDirection = Random.insideUnitSphere * radiusMax; // get direction
        posCheck = randomDirection;

        Vector3 PickedPosition = _FighterSM.transform.position + randomDirection;
        PickedPosition = new Vector3(PickedPosition.x, 0, PickedPosition.z);

        // Is picked position inside arena bounds ?
        if (Vector3.Distance(PickedPosition, _ArenaCenter) < _ArenaSize) {
            // valid position
            _FighterSM.MovePosition = PickedPosition;
        } else {
            // wrong position
            Vector3 TowardArenaCenter = _ArenaCenter - PickedPosition;
            float OutRange = Vector3.Distance(PickedPosition, _ArenaCenter) - _ArenaSize;
            PickedPosition = PickedPosition + TowardArenaCenter * OutRange;
        }
    }
}