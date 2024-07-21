using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private LevelsUnlockedSO levelsUnlocked;

    [SerializeField] private List<Button> levels = new List<Button>();

    private void Start()
    {
        CheckLevels();
    }

    private void CheckLevels()
    {
        foreach (Button l in levels)
        {
            l.enabled = false;
        }
    }
}
