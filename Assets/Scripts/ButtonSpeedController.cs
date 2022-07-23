using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonSpeedController : MonoBehaviour {
    public GUIManager GUIManager;
    public Button Button;
    public TextMeshProUGUI Text;
    public float Speed;

    void Awake() {
        if (GUIManager == null) GUIManager = this.GetComponentInParent<GUIManager>();
        if (Button == null) Button = this.GetComponent<Button>();
        if (Text == null) Text = GetComponentInChildren<TextMeshProUGUI>();

        Button.onClick.AddListener(delegate { GUIManager.BattleManager.SetGameSpeed(Speed); });
        if (Speed == 0) {
            Text.text = "| |";
        } else {
            Text.text = "x" + Speed.ToString();
        }

    }

}
