using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "State/BasicMove")]
public class State_BasicMove : BaseState {

    Tween Tween;

    public override void EnterState(FighterSM _FighterSM) { // Do enter shit once
        //Debug.LogWarning("Entering BasicWalk");
        MoveToPosition(_FighterSM, _FighterSM.MovePosition);
    }

    public override void UpdateState(FighterSM _FighterSM) { // Do things
        if (!Tween.IsPlaying()) {
            _FighterSM.SwitchState(_FighterSM.idle);
        }
    }

    public override void ExitState(FighterSM _FighterSM) { // End things if needed

    }

    public Tween MoveToPosition(FighterSM _FighterSM, Vector3 _EndPoint) {
        _EndPoint = new Vector3(_EndPoint.x, 0f, _EndPoint.z);
        // temps = dist / vitesse
        float MoveTime = Mathf.Abs(Vector3.Distance(_FighterSM.transform.position, _EndPoint) / _FighterSM.FighterEntity.ComputedMoveSpeed);
        return Tween = _FighterSM.transform.DOMove(_EndPoint, MoveTime).SetEase(Ease.InOutExpo);
    }
}
