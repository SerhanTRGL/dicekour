using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpParticleEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleEffect;
    [SerializeField] private PolygonCollider2D pg;
    // Update is called once per frame
    private void Start() {
        var main = particleEffect.main;
        main.duration = 0.20f;
        main.startLifetime = 0.20f;
    }
    void Update(){
        if (Input.GetMouseButtonDown(0) && pg.IsTouchingLayers()) {
            particleEffect.Play();
            particleEffect.transform.position = transform.position;
            var velocityOverLifetime = particleEffect.velocityOverLifetime;
            Vector3 throwDirection = -GetThrowDirection();
            velocityOverLifetime.x = throwDirection.x;
            velocityOverLifetime.y = throwDirection.y;
            velocityOverLifetime.z = throwDirection.z;

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
