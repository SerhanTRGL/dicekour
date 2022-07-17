using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SideTracker : MonoBehaviour {
    [SerializeField] private PolygonGenerator polygonGenerator;
    [SerializeField] private TextMeshPro text;
    [SerializeField] private BoxCollider2D[] colliders;
    private float sides;

    private int currentNumber;
    private int previousNumber;
    // Start is called before the first frame update
    void Start() {
        currentNumber = 0;
        previousNumber = 0;
        sides = polygonGenerator.polygonSides;
        text.text = currentNumber.ToString();
    }

    // Update is called once per frame
    void Update() {
        currentNumber = GetTouchingSurface();
        if(currentNumber != previousNumber) {
            text.text = currentNumber.ToString();
            previousNumber = currentNumber;
        }
    }

    public int GetTouchingSurface() {
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].IsTouchingLayers(LayerMask.GetMask("Ground"))) {
                return i + 1;
            }
        }
        return 0;
    }
}
