using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class FighterSM : MonoBehaviour {
    public FighterEntity FighterEntity;
    public BrainManager BrainManager;
    public Animator AnimatorController;
    public State_BasicIdle idle;

    [Header("CURRENT STATE")]
    public BaseState CurrentState;
    public Vector3 DebugTargetMovement = Vector3.zero;

    void Start() {
        MakeNewDecision();
        AnimatorController = GetComponentInChildren<Animator>();
    }

    void Update() {
        CurrentState.UpdateState(this);
        // Look At
        Vector3 Target = new Vector3(FighterEntity.EnemyFighter.transform.position.x, 0, FighterEntity.EnemyFighter.transform.position.z);
        this.transform.LookAt(Target);
        // MouseMovement();
    }

    public void SwitchState(BaseState _State) {
        // Debug.Log("Switch to " + _State);
        CurrentState = _State;
        _State.EnterState(this);
    }

    public void MakeNewDecision() {
        // get a decision and play it
        BaseState decision = BrainManager.PickAction();
        SwitchState(decision);
    }

    void OnDrawGizmos() {
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawLine(this.transform.position, DebugTargetMovement);
        // UnityEditor.Handles.DrawWireDisc(FighterEntity.EnemyFighter.transform.position, Vector3.up, FighterEntity.MainWeapon.AttackRange);
    }

    void MouseMovement() {
        if (Input.GetMouseButtonDown(0)) {
            DebugTargetMovement = Vector3.zero;
            DebugTargetMovement = GetPositionOfClick();
            // SwitchState(move);
        }
    }

    public Vector3 GetPositionOfClick() {
        Plane plane = new Plane(Vector3.up, 0);
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.cyan, 1f);

        if (plane.Raycast(ray, out distance)) {
            DebugTargetMovement = new Vector3(ray.GetPoint(distance).x, 0, ray.GetPoint(distance).z);
            return DebugTargetMovement;
        }
        return Vector3.zero;
    }
}