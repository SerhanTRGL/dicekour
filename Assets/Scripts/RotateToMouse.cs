using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public LineRenderer lr;
    public TextMeshPro tmp;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 0.2f;
        lr.endWidth = 0.05f;
        lr.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + GetThrowDirection()*int.Parse(tmp.text)* 0.7f);
 
    }
    private Vector3 GetThrowDirection() {
        Vector3 dicePosition = Camera.main.WorldToScreenPoint(transform.position);
        dicePosition.Set(dicePosition.x, dicePosition.y, 0);

        Vector3 mousePosition = Input.mousePosition;
        Vector3 throwDirection = mousePosition - dicePosition;

        return throwDirection.normalized;
    }
}
