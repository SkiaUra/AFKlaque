using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Inventory", fileName = "new Inventory")]
public class ItemInventory : ScriptableObject {
    public List<ItemTemplate> PlayerInventory = new List<ItemTemplate>();
}
