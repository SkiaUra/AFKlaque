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
    public int CurrentHealth;
    public int MaxHealth;
    public float MoveSpeed;
    public float MoveRange;

    public WeaponTemplate MainWeapon;
    public float CountdownMainWeapon;

    public Tween MovementTween;

    void Start() {
        SetupEntity(FighterTemplate);
    }

    void Update() {
        // MainWeaponCycle();
        
    }



    public void SetupEntity(FighterTemplate _Template) {
        MaxHealth = _Template.HealthPoints;
        CurrentHealth = MaxHealth;
        MoveSpeed = _Template.MoveSpeed;
        CountdownMainWeapon = MainWeapon.AttackSpeed;
    }
}