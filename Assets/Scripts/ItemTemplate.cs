using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Un item generique. Le type défini ce qui est équipable.
// TODO => une class ou struct Stat + value. Stat doit etre un enum d'ailleurs !

[CreateAssetMenu(menuName = "Create Item", fileName = "New Item")]
public class ItemTemplate : ScriptableObject {
    public ItemType ItemType;
    public Sprite Icon;
}
