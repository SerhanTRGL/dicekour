using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRespawnPointTracker : MonoBehaviour
{
    [SerializeField, NonReorderable] private BoxCollider2D[] respawnPoints;
    [SerializeField, NonReorderable] private List<bool> activeStates;

    private void Awake() {
        respawnPoints = GetComponentsInChildren<BoxCollider2D>();
        activeStates = new List<bool>();
        for(int i = 0; i < respawnPoints.Length; i++) {
            activeStates.Add(false);
        }
    }

    private void SetAllInactive() {
        for (int i = 0; i < activeStates.Count; i++) {
            activeStates[i] = false;
        }
    }
    public void SetActiveStateOf(int index) {
        SetAllInactive();
        activeStates[index] = true;
    }

    public Vector3 GetPositionOfActiveRespawnPoint() {
        Vector3 pos = Vector3.zero;
        for(int i = 0; i < activeStates.Count; i++) {
            if (activeStates[i] == true) {
                pos = respawnPoints[i].transform.position;
                pos.y += 0.5f;
                break;
            }
        }
        return pos;
    }
}
