using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private ActiveRespawnPointTracker respawnTracker;
    private CircleCollider2D circleCollider2D;
    
    private void Start() {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Respawn")) {
            respawnTracker.SetActiveStateOf(collision.GetComponent<RespawnPointInfo>().GetRespawnPointNumber());
        }
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Kill") && circleCollider2D.IsTouchingLayers(LayerMask.GetMask("Kill"))) {
            ControlDeathCounter.instance.IncrementDeathCounter();
            transform.position = respawnTracker.GetPositionOfActiveRespawnPoint();
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
