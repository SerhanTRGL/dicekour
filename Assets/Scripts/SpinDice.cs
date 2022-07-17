using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinDice : MonoBehaviour
{
    [SerializeField] private SideTracker sideTracker;
    [SerializeField] private CircleCollider2D safeArea;
    [SerializeField] private PolygonCollider2D polygonBody;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PhysicsMaterial2D pm2d;
    private bool torqueAdded = false;
    private bool onAir = false;
    void FixedUpdate()
    {
        if (!safeArea.IsTouchingLayers(LayerMask.GetMask("Ground")) && sideTracker.GetTouchingSurface() == 0) {
            //Add torque once
            if(torqueAdded == false) {
                rb.AddTorque(Random.Range(5, 50));
                torqueAdded = true;
            }
        }

        if (safeArea.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            rb.angularDrag = 100000;
            torqueAdded = false;
        }
        else {
            rb.angularDrag = 0;
        }

        if (Mathf.Abs(rb.angularVelocity) < 100) {
            rb.angularDrag = 0;
        }

        if (sideTracker.GetTouchingSurface() == 0) {
            onAir = true;
        }
        else {
            onAir = false;
        }
        if(safeArea.IsTouchingLayers(LayerMask.GetMask("Ground")) && polygonBody.IsTouchingLayers(LayerMask.GetMask("Ground")) && !onAir) {
            rb.velocity = Vector2.zero;
        }
    }
}
