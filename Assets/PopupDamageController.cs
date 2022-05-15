using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class PopupDamageController : MonoBehaviour {

    public TextMeshProUGUI Text;
    public Tween ShowTween;
    public int Damage;

    void Awake() {
        this.transform.localScale = Vector3.zero;
        this.enabled = false;
    }

    void OnEnable() {
        Show();
    }

    void Show() {
        this.transform.localScale = Vector3.zero;
        Text.text = Damage.ToString();
        this.transform.DOScale(Vector3.one, 1f)
                .SetEase(Ease.OutBack)
                .OnComplete(() => {
                    this.GetComponent<PopupDamageController>().enabled = false;
                    this.transform.localScale = Vector3.zero;
                });
    }
}
