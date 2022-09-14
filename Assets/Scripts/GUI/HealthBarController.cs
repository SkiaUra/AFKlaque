using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBarController : MonoBehaviour {
    public FighterEntity LinkedFighter;

    [Header("Bindings")]
    public Slider Slider;

    public float LastFrameHP = -1;
    public float CurrentFrameHP;

    Tween Tween;

    void Update() {
        if (LinkedFighter) CheckHealthChanges();
    }

    void CheckHealthChanges() {
        // get 
        CurrentFrameHP = LinkedFighter.ComputedCurrentHealth;
        if (LastFrameHP < 0) LastFrameHP = CurrentFrameHP;

        // compare
        if (CurrentFrameHP != LastFrameHP) {
            Tween = Slider.DOValue(CurrentFrameHP, 0.5f);
        }
    }

    void RefreshSlider(float _NewValue) {
        Slider.DOValue(_NewValue, 0.5f);
    }

    public void SetupHealthBar(FighterEntity _FighterEntity) {
        LinkedFighter = _FighterEntity;
        Slider.minValue = 0f;
        Slider.maxValue = _FighterEntity.ComputedMaxHealth;
        Slider.value = Slider.maxValue;
    }
}
