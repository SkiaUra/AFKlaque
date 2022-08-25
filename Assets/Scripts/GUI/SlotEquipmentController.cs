using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Sirenix.OdinInspector;
using DG.Tweening;

public class SlotEquipmentController : MonoBehaviour {
    // temporary
    public ItemInventory Inventory;

    public FighterTemplate LinkedFighter;
    public CharacterSlot LinkedSlot;
    public ItemType SlotOfType;

    [Header("Bindings")]
    public bool isInventoryOpen = false;
    public GameObject InventoryLayout;
    public List<ButtonItemDisplay> InventoryButtons = new List<ButtonItemDisplay>();
    public ButtonItemDisplay SelectedInventoryButton;
    public GameObject InfoBlock;
    public ButtonItemDisplay ActiveSlot;

    void Start() {
        InventoryLayout.transform.localScale = Vector3.zero;
        SetupInventoryList();
        if (ActiveSlot) ActiveSlot.GetComponent<Button>().onClick.AddListener(SwitchInventoryDisplay);
    }

    void SwitchInventoryDisplay() {
        Debug.Log("You have clicked the button!");
        if (isInventoryOpen) {
            InventoryLayout.transform.DOScale(0, 0.2f);
        } else {
            InventoryLayout.transform.DOScale(1, 0.2f);
        }
        isInventoryOpen = !isInventoryOpen;
    }

    [Button("Update Inventory")]
    void UpdateInventoryBlockDisplay() {
        List<ItemTemplate> FilteredList = Inventory.PlayerInventory.Where(t => t.ItemType == SlotOfType).ToList();

        for (int i = 0; i < InventoryButtons.Count; i++) {
            if (i < FilteredList.Count) {
                // ajoute l'item
                InventoryButtons[i].DisplayedItem = FilteredList[i];
                InventoryButtons[i].UpdateDisplay();
                InventoryButtons[i].gameObject.SetActive(true);
            } else {
                // cache le slot
                InventoryButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void SetupInventoryList() {
        InventoryButtons.Clear();
        foreach (Transform item in InventoryLayout.transform) {
            ButtonItemDisplay button = item.GetComponent<ButtonItemDisplay>();
            InventoryButtons.Add(button);
            button.GetComponent<Button>().onClick.AddListener(delegate { SelectedSlotToActiveSlot(button); });
        }
        UpdateInventoryBlockDisplay();
    }

    void SelectedSlotToActiveSlot(ButtonItemDisplay button) {
        if (SelectedInventoryButton == button) {
            Debug.Log("Add item " + button.DisplayedItem + " to " + LinkedSlot);
            ActiveSlot.DisplayedItem = button.DisplayedItem;
            ActiveSlot.UpdateDisplay();
            if (LinkedSlot != null) LinkedSlot.AssignItem(button.DisplayedItem);
        } else {
            SelectedInventoryButton = button;
        }
    }

    public void AddItemToActiveSlot(ItemTemplate itemTemplate) {
        ActiveSlot.DisplayedItem = itemTemplate;
        ActiveSlot.UpdateDisplay();
    }

}
