using UnityEngine;

public class ScreenController : MonoBehaviour {
    public ScreenType screen;

    public RectTransform rectTransform;
    public Vector2 resolution;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
    }
    /*
        void Update() {
            resolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
            rectTransform.offsetMin = new Vector2(-resolution.x, 0); // Left, Bot
            rectTransform.offsetMax = new Vector2(-resolution.x, 0); // -Right, -Top
        }
    */
}