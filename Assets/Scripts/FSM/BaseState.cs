using UnityEngine;

public abstract class BaseState : ScriptableObject {

    protected ToolboxMovement _ToolboxMovement = new ToolboxMovement();

    public abstract void EnterState(FighterSM FighterSM);

    public abstract void UpdateState(FighterSM FighterSM);

    public abstract void ExitState(FighterSM FighterSM, bool startNewDecision);

}