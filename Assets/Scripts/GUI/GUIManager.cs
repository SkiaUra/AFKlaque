using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GUIManager : MonoBehaviour {
    public enum ScreenType {
        EQUIPMENTSCREEN = 0,
        LOBBYSCREEN = 1
    }

    [Header("Bindings")]
    public GameMaster GameMaster;
    public BattleManager BattleManager;
    public HealthBarController PlayerHealthBar;
    public HealthBarController EnemyHealthBar;

    public PopupDamageController PrefabPopupDamage;

    [Header("Buttons")]
    public Button EquipmentScreenButton;
    public Button LobbyScreenButton;
    public Button StartBattleButton;
    public Button BackToLobby;

    [Header("Components")]
    public RectTransform ScreenMover;

    public List<GameObject> GUILobby = new List<GameObject>();
    public List<GameObject> GUIBattle = new List<GameObject>();

    void Start() {
        if (LobbyScreenButton) LobbyScreenButton.onClick.AddListener(delegate { MoveScreens(ScreenType.LOBBYSCREEN); });
        if (EquipmentScreenButton) EquipmentScreenButton.onClick.AddListener(delegate { MoveScreens(ScreenType.EQUIPMENTSCREEN); });
        if (StartBattleButton) StartBattleButton.onClick.AddListener(delegate { GameMaster.SwitchToBattle(); });
        if (BackToLobby) BackToLobby.onClick.AddListener(delegate { GameMaster.SwitchToLobby(); });
    }

    void MoveScreens(ScreenType screenType) {
        switch (screenType) {
            case ScreenType.LOBBYSCREEN:
                ScreenMover.DOAnchorPos(Vector3.right * 0, 0.2f).SetEase(Ease.OutQuint);
                break;
            case ScreenType.EQUIPMENTSCREEN:
                ScreenMover.DOAnchorPos(Vector3.right * -1 * Screen.currentResolution.width, 0.2f).SetEase(Ease.OutQuint);
                break;
        }
    }

    public void DisplayLobbyGUI() {
        foreach (GameObject gameObject in GUIBattle) {
            gameObject.SetActive(false);
        }
        foreach (GameObject gameObject in GUILobby) {
            gameObject.SetActive(true);
        }
    }

    public void DisplayBattleGUI() {
        foreach (GameObject gameObject in GUILobby) {
            gameObject.SetActive(false);
        }
        foreach (GameObject gameObject in GUIBattle) {
            gameObject.SetActive(true);
        }
    }
}