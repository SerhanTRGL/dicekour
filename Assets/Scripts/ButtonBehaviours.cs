using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviours : MonoBehaviour {
    [SerializeField] private Rigidbody2D rb = null;

    public void QuitGame() {
        Application.Quit();
    }

    public void MuteAndUnmuteGame() {
        if(rb != null) {
            rb.velocity = Vector2.zero;
            rb.Sleep();
        }
        
        if (SoundManager.instance.gameObject.activeSelf) {
            SoundManager.instance.gameObject.SetActive(false);
        }
        else {
            SoundManager.instance.gameObject.SetActive(true);
        }
        
        if(rb != null) {
            rb.WakeUp();
        }
    }
}
