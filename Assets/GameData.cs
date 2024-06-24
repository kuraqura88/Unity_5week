using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class GameData
{
    public int GameScore;
    public int GameMoney;
    public int GameUpgrade;
    public bool[] isClear = new bool[3];
}
