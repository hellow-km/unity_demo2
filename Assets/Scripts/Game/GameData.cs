using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoSingleton<GameData>
{
    public float maxCutProgress=100;
    public float cutSpeed = 1;
    public float maxCookProgress = 100;
    public float cookSpeed = 1;
    public float maxPlateCount = 3;
    public float plateAddSpeed = 1;
    public float plateMaxProgress = 100;
}
