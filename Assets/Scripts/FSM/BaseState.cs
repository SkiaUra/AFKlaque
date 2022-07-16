using UnityEngine;

public abstract class BaseState : ScriptableObject {

    protected ToolboxMovement _ToolboxMovement = new ToolboxMovement();

    public abstract void EnterState(FighterSM _FighterSM);

    public abstract void UpdateState(FighterSM _FighterSM);

    public abstract void ExitState(FighterSM _FighterSM);
}