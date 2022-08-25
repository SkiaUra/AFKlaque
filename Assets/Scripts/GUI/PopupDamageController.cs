using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class PopupDamageController : MonoBehaviour {

    public FighterEntity LinkedFighter;
    public TextMeshProUGUI Text;
    public Tween ShowTween;
    public int Damage;
    public float DisplaySpeed = 0.5f;
    public float DisplayHeightOffset = 0f;

    void Awake() {
        this.transform.localScale = Vector3.zero;
    }

    public void Show() {
        this.transform.position = Camera.main.WorldToScreenPoint(LinkedFighter.EnemyFighter.transform.position);
        this.transform.localScale = Vector3.zero;
        Text.text = LinkedFighter.MainWeaponDamage.ToString();
        this.transform.DOMoveY(transform.position.y + DisplayHeightOffset, DisplaySpeed).SetEase(Ease.OutBack);
        this.transform.DOScale(Vector3.one, DisplaySpeed)
                .SetEase(Ease.OutBack)
                .OnComplete(() => {
                    this.transform.localScale = Vector3.zero;
                });
    }
}
