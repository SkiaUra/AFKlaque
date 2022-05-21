using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class BattleData {
    public BATTLEDATA DataType;
    public float DataValue;
}

public enum BATTLEDATA {
    // Floats
    CurrentHP = 0,
    PercentHP,
    EnemyCurrentHP,
    EnemyPercentHP

    // Bools

}

// [CreateAssetMenu(menuName = "BattleDatas")]
public class BattleDataManager : MonoBehaviour {
    [Required]
    public FighterEntity Fighter;

    public List<BattleData> BattleDatas = new List<BattleData>() {
        new BattleData() {DataType = BATTLEDATA.CurrentHP},
        new BattleData() {DataType = BATTLEDATA.PercentHP},
    };

    void Start() {
        if (Fighter == null) this.GetComponent<FighterEntity>();
    }

    void Update() {
        /*
        foreach (BattleData item in BattleDatas) {
            item.DataValue = UpdateData(item);
        }
        */
    }

    float UpdateData(BattleData _DataType) {
        switch (_DataType.DataType) {
            case BATTLEDATA.CurrentHP:
                return Fighter.ComputedCurrentHealth;
            case BATTLEDATA.PercentHP:
                return Fighter.ComputedCurrentHealth;
            default:
                return 0;
        }
    }
}

