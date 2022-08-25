using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterSlot {

    public ItemType ItemTypeInSlot;
    public ItemTemplate ItemInSlot;

    public CharacterSlot(ItemType t, ItemTemplate i) {
        ItemTypeInSlot = t;
        ItemInSlot = i;
    }

    public void AssignItem(ItemTemplate item) {
        ItemInSlot = item;
    }

    public void RemoveItem() {
        ItemInSlot = null;
    }
}

[CreateAssetMenu(fileName = "New Fighter")]
public class FighterTemplate : ScriptableObject {

    public int Health = 0;
    public float MoveSpeed = 0.5f;
    public float MoveDelay = 1f;
    public float MoveRange = 0.5f;
    public float Size = 1f;

    [Header("Equipment slots")]
    public CharacterSlot MainWeaponSlot = new CharacterSlot(ItemType.WEAPON, null);
    public CharacterSlot OffWeaponSlot = new CharacterSlot(ItemType.WEAPON, null);
    public CharacterSlot HatSlot = new CharacterSlot(ItemType.HEAD, null);
    public CharacterSlot TrinketSlot = new CharacterSlot(ItemType.TRINKET, null);
    public CharacterSlot BehaviourSlot1 = new CharacterSlot(ItemType.BEHAVIOUR, null);
    public CharacterSlot BehaviourSlot2 = new CharacterSlot(ItemType.BEHAVIOUR, null);
    public CharacterSlot BehaviourSlot3 = new CharacterSlot(ItemType.BEHAVIOUR, null);


    [Header("FSM setup")]
    public State_BasicIdle idle;
    public State_BasicHit hit;

    // Soon to remove
    public WeaponTemplate MainWeapon;
    public WeaponTemplate OffWeapon;

}
