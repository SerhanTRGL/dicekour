using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAxis : MonoBehaviour {
    [SerializeField] private Transform centerPoint;
    public Vector3 GetRotationAxis() { 
        return transform.position - centerPoint.position;
    }
}
