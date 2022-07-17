using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrowScript : MonoBehaviour {
    [SerializeField] private Rigidbody2D diceBody;
    [SerializeField] private int explosionCoefficient = 1;
    [SerializeField] private float explosionMagnitude = 500;
    [SerializeField] private SideTracker sideTracker;

    [SerializeField] private AudioClip[] jumpSounds;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + GetThrowDirection());

        explosionCoefficient = sideTracker.GetTouchingSurface();
        if (Input.GetMouseButtonDown(0)) {
            if (explosionCoefficient > 0 && SoundManager.instance != null) {
                SoundManager.instance.PlaySound(jumpSounds[explosionCoefficient - 1]);
            }
            diceBody.AddForce(GetThrowDirection()*explosionCoefficient*explosionMagnitude);
        }
    }

    private Vector3 GetThrowDirection() {
        Vector3 dicePosition = Camera.main.WorldToScreenPoint(transform.position);
        dicePosition.Set(dicePosition.x, dicePosition.y, 0);

        Vector3 mousePosition = Input.mousePosition;
        Vector3 throwDirection = mousePosition - dicePosition;

        return throwDirection.normalized;
    }
}
