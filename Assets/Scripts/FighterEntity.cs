using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class FighterEntity : MonoBehaviour {
    public BattleManager BattleManager;
    public FighterTemplate FighterTemplate;
    public FighterEntity EnemyFighter;
    public FighterSM FighterSM;

    public Material Material;
    public PopupDamageController PopupDamage;

    [Header("Stats")]
    public int ComputedCurrentHealth;
    public int ComputedMaxHealth;
    public float ComputedMoveSpeed;
    public float ComputedMoveDelay;
    public float ComputedMoveRange;

    [Header("Main Weapon")]
    public WeaponTemplate MainWeapon;
    public int MainWeaponDamage;
    public float MainWeaponRange;
    public float MainWeaponCountdown;


    public void Update() {

    }

    public void SetupEntity(FighterTemplate _Template) {
        // Bind FSM
        FighterSM = this.GetComponent<FighterSM>();

        // Setup Materials
        foreach (Transform MeshChild in this.transform) {
            MeshChild.GetComponent<MeshRenderer>().material = Material;
        }

        PopupDamage = Instantiate(BattleManager.GUIManager.PrefabPopupDamage, BattleManager.GUIManager.transform);
        PopupDamage.LinkedFighter = this;

        // Computed Stats
        ComputedMaxHealth = _Template.Health;
        ComputedCurrentHealth = ComputedMaxHealth;
        ComputedMoveSpeed = _Template.MoveSpeed;
        ComputedMoveDelay = _Template.MoveDelay;
        ComputedMoveRange = _Template.MoveRange;

        // Main Weapon
        MainWeapon = _Template.MainWeapon;
        MainWeaponDamage = MainWeapon.damage;
        MainWeaponRange = MainWeapon.AttackRange;
        MainWeaponCountdown = MainWeapon.AttackSpeed;

        FighterSM.enabled = true;
    }
}