using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;

[System.Serializable]
public class BattleData {
    public BATTLEDATA DataType;
    public float DataValue;
}

public enum BATTLEDATA {
    Float = -1,

    // Player
    HP = 0,
    PercentHP = 1,
    MoveDelay = 2,
    MoveRange = 3,

    // Weapons
    MainWeaponDelay = 10,
    MainWeaponRange = 11,

    AttackDelay2 = 15,

    // Enemy
    EnemyHP = 20,
    EnemyPercentHP = 21,

    // Arena
    DistanceFromEnemy = 40,
    DistanceFromArenaCenter = 41,

    // Bools

}

public class BattleDataManager : MonoBehaviour {
    [Required]
    public FighterEntity Fighter;

    //[ReadOnly]
    [ListDrawerSettings(OnTitleBarGUI = "RebuildBattleDataList")]
    public List<BattleData> BattleDatas = new List<BattleData>();

    void Start() {
        if (Fighter == null) this.GetComponent<FighterEntity>();
        RebuildBattleDataList();
    }

    void LateUpdate() {

        foreach (BattleData item in BattleDatas) {
            item.DataValue = UpdateData(item);
        }

    }

    float UpdateData(BattleData _DataType) {
        switch (_DataType.DataType) {

            //PLAYER
            case BATTLEDATA.HP:
                return Fighter.ComputedCurrentHealth;
            case BATTLEDATA.PercentHP:
                return Fighter.ComputedCurrentHealth;
            case BATTLEDATA.MoveDelay:
                return Fighter.ComputedMoveDelay;
            case BATTLEDATA.MoveRange:
                return Fighter.ComputedMoveRange;
            // WEAPONS
            case BATTLEDATA.MainWeaponDelay:
                return Fighter.MainWeaponCountdown;
            case BATTLEDATA.MainWeaponRange:
                return Fighter.MainWeaponRange;

            // ENEMY
            case BATTLEDATA.EnemyHP:
                return Fighter.EnemyFighter.ComputedCurrentHealth;
            case BATTLEDATA.EnemyPercentHP:
                return Fighter.EnemyFighter.ComputedCurrentHealth;

            // ARENA
            case BATTLEDATA.DistanceFromEnemy:
                return Vector3.Distance(Fighter.transform.position, Fighter.EnemyFighter.transform.position);
            case BATTLEDATA.DistanceFromArenaCenter:
                return Vector3.Distance(Fighter.transform.position, Fighter.BattleManager.ArenaCenter);
            default:
                return -666;
        }
    }

    void RebuildBattleDataList() {
        if (BattleDatas.Count > 0) BattleDatas.Clear();
        foreach (BATTLEDATA data in System.Enum.GetValues(typeof(BATTLEDATA))) {
            if (data == BATTLEDATA.Float) continue;
            BattleDatas.Add(new BattleData() {
                DataType = data,
                DataValue = 0
            });
        }
    }
}

