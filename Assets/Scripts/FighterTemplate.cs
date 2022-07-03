using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fighter")]
public class FighterTemplate : ScriptableObject {

    public int Health = 0;
    public float MoveSpeed = 0.5f;
    public float MoveDelay = 1f;
    public float MoveRange = 0.5f;
    public float Size = 1f;

    [Header("FSM setup")]
    public State_BasicIdle idle;
    public State_BasicMove move;
    public State_BasicAttack attack;

    public WeaponTemplate MainWeapon;
    public WeaponTemplate OffWeapon;
}
