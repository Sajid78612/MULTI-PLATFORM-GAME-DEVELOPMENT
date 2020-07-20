using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;

    public PlayerData(pausemenu p) {
        level = p.level;
    }
    public PlayerData(summary s) {
        level = s.level;
    }
}
