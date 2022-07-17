using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class RespawnPointInfo : MonoBehaviour
{
    public int GetRespawnPointNumber() {
        return int.Parse(Regex.Match(this.name, @"\d+").Value);
    }
}
