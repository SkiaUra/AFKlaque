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
            SeekValidedestination(_FighterSM, MinMoveRange, MaxMoveRange);
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

    void SeekValidedestination(FighterSM _FighterSM, float radiusMin, float radiusMax) {
        Rect Bounds = _FighterSM.FighterEntity.BattleManager.Area;
        Vector3 randomDirection = Random.insideUnitSphere * radiusMax; // get direction
        posCheck = randomDirection;

        Vector3 calculatedPosition = _FighterSM.transform.position + randomDirection;

        calculatedPosition = new Vector3(
            Mathf.Clamp(calculatedPosition.x, -0.5f * Bounds.size.x, 0.5f * Bounds.size.x),
            0f,
            Mathf.Clamp(calculatedPosition.z, -0.5f * Bounds.size.y, 0.5f * Bounds.size.y));// on XZ only

        _FighterSM.MovePosition = calculatedPosition;
    }


}