using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fighter")]
public class FighterTemplate : ScriptableObject {

    public int Health = 0;
    public float MoveSpeed = 0.5f;

    [Header("FSM setup")]
    public State_BasicIdle idle;
    public State_BasicMove move;
    public State_BasicAttack attack;

    public WeaponTemplate MainWeapon;
    public WeaponTemplate OffWeapon;
}
