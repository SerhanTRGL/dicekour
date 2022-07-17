using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ActivatePostProcessLayer : MonoBehaviour
{
    [SerializeField] private PostProcessLayer ppl;
    void Start()
    {
        ppl.enabled = true;   
    }
}
