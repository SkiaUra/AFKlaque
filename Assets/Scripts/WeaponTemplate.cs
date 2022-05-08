using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon")]
public class WeaponTemplate : ScriptableObject {
    public int damage;
    public float AttackSpeed;
    public float AttackRange;
    // TODO Skills
}
