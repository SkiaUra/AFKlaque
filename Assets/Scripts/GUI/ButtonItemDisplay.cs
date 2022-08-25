using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItemDisplay : MonoBehaviour {
    public ItemTemplate DisplayedItem;
    public Image Sprite;

    public void UpdateDisplay() {
        Sprite.sprite = DisplayedItem.Icon;
    }
}
