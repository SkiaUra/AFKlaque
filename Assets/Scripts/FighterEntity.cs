using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FighterEntity : MonoBehaviour {
    public BattleManager BattleManager;
    public FighterTemplate FighterTemplate;
    public FighterSM FighterSM;

    public FighterEntity EnemyFighter;

    [Header("Stats")]
    public int ComputedCurrentHealth;
    public int ComputedMaxHealth;
    public float ComputedMoveSpeed;

    public WeaponTemplate MainWeapon;
    public float CountdownMainWeapon;

    public Tween MovementTween;



    public void SetupEntity(FighterTemplate _Template) {
        // Bind FSM
        FighterSM = this.GetComponent<FighterSM>();
        // Computed Stats
        ComputedMaxHealth = _Template.HealthPoints;
        ComputedCurrentHealth = ComputedMaxHealth;
        ComputedMoveSpeed = _Template.MoveSpeed;
        CountdownMainWeapon = MainWeapon.AttackSpeed;

    }
}