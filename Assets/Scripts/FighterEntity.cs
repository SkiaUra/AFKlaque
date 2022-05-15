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

    [Header("Main Weapon")]
    public WeaponTemplate MainWeapon;
    public int MainWeaponDamage;
    public float MainWeaponRange;
    public float MainWeaponCountdown;

    public Tween MovementTween;



    public void SetupEntity(FighterTemplate _Template) {
        // Bind FSM
        FighterSM = this.GetComponent<FighterSM>();
        FighterSM.idle = Instantiate(_Template.idle);
        FighterSM.attack = Instantiate(_Template.attack);
        FighterSM.move = Instantiate(_Template.move);

        // Computed Stats
        ComputedMaxHealth = _Template.Health;
        ComputedCurrentHealth = ComputedMaxHealth;
        ComputedMoveSpeed = _Template.MoveSpeed;

        // Main Weapon
        MainWeapon = _Template.MainWeapon;
        MainWeaponDamage = MainWeapon.damage;
        MainWeaponRange = MainWeapon.AttackRange;
        MainWeaponCountdown = MainWeapon.AttackSpeed;
    }
}