using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsUnlocked", menuName = "Levels/Levels Unlocked")]
public class LevelsUnlockedSO : ScriptableObject
{
    public List<string> levelsUnlocked = new List<string>();
}
