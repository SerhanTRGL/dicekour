using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlDeathCounter : MonoBehaviour
{
    public static ControlDeathCounter instance;
    private int deathcount = 0;
    public int DeathCount { get; private set; }

    private void Awake() {
        instance = this;
        DontDestroyOnLoad(this);
    }
    

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = DeathCount.ToString();
    }

    public void IncrementDeathCounter() {
        DeathCount++;
    }
}
