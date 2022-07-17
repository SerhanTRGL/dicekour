using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetToNextLevel : MonoBehaviour
{
    private IEnumerator coroutine;
    private bool nextLevelLoadStarted = false;
    [SerializeField] private TextMeshPro levelEndText = null;

    private void Awake() {
        if(levelEndText != null) {
            levelEndText.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Finish") && !nextLevelLoadStarted) {
            nextLevelLoadStarted = true;
            GetComponent<BoxCollider2D>().enabled = false;
            coroutine = StartCounterAndLoadNextScene();
            StartCoroutine(coroutine);
            if(levelEndText != null) {
                levelEndText.enabled = true;
            }
        }
    }  

    private IEnumerator StartCounterAndLoadNextScene() { 
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

