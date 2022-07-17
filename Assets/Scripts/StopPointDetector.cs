using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPointDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("stoppoint")) {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.SetActive(false);
        }
    }
}
