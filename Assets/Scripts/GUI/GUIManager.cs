using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GUIManager : MonoBehaviour {

    [Header("Bindings")]
    public BattleManager BattleManager;
    public HealthBarController PlayerHealthBar;
    public HealthBarController EnemyHealthBar;

    public PopupDamageController PrefabPopupDamage;

    public Button EquipmentScreenButton;
    public Button LobbyScreenButton;
    public RectTransform ScreenMover;

    void Start() {
        if (LobbyScreenButton) LobbyScreenButton.onClick.AddListener(delegate { MoveScreens(ScreenType.LOBBYSCREEN); });
        if (EquipmentScreenButton) EquipmentScreenButton.onClick.AddListener(delegate { MoveScreens(ScreenType.EQUIPMENTSCREEN); });

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
}