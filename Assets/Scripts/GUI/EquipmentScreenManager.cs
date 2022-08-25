using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentScreenManager : MonoBehaviour {
    public FighterTemplate LinkedFighter;

    [Header("Slot Bindings")]
    public SlotEquipmentController MainWeaponSlot;
    public SlotEquipmentController OffWeaponSlot;
    public SlotEquipmentController HatSlot;
    public SlotEquipmentController TrinketSlot;
    public SlotEquipmentController BehaviourSlot1;
    public SlotEquipmentController BehaviourSlot2;
    public SlotEquipmentController BehaviourSlot3;

    void Start() {
        if (LinkedFighter) BindFighter(LinkedFighter);
    }

    void BindFighter(FighterTemplate fighterTemplate) {
        MainWeaponSlot.LinkedSlot = fighterTemplate.MainWeaponSlot;
        OffWeaponSlot.LinkedSlot = fighterTemplate.OffWeaponSlot;
        HatSlot.LinkedSlot = fighterTemplate.HatSlot;
        TrinketSlot.LinkedSlot = fighterTemplate.TrinketSlot;
        BehaviourSlot1.LinkedSlot = fighterTemplate.BehaviourSlot1;
        BehaviourSlot2.LinkedSlot = fighterTemplate.BehaviourSlot2;
        BehaviourSlot3.LinkedSlot = fighterTemplate.BehaviourSlot3;

        MainWeaponSlot.AddItemToActiveSlot(fighterTemplate.MainWeaponSlot.ItemInSlot);
        OffWeaponSlot.AddItemToActiveSlot(fighterTemplate.OffWeaponSlot.ItemInSlot);
        HatSlot.AddItemToActiveSlot(fighterTemplate.HatSlot.ItemInSlot);
        TrinketSlot.AddItemToActiveSlot(fighterTemplate.TrinketSlot.ItemInSlot);
        BehaviourSlot1.AddItemToActiveSlot(fighterTemplate.BehaviourSlot1.ItemInSlot);
        BehaviourSlot2.AddItemToActiveSlot(fighterTemplate.BehaviourSlot2.ItemInSlot);
        BehaviourSlot3.AddItemToActiveSlot(fighterTemplate.BehaviourSlot3.ItemInSlot);
    }
}
