using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    [Header("Bindings")]
    public BattleManager BattleManager;
    public HealthBarController PlayerHealthBar;
    public HealthBarController EnemyHealthBar;

    public PopupDamageController PrefabPopupDamage;
}
