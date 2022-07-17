using TMPro;
using UnityEngine;

public class TextColorSet : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    void Start()
    {
        text.color = Color.black;
    }
}
