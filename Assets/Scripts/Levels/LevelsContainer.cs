using System.Collections.Generic;
using UnityEngine;

public class LevelsContainer : MonoBehaviour, ILevelContain
{
    public List<LevelModelBase> Levels { get; } = new List<LevelModelBase>()
    {
        new BaseLevel(5, 30, 2, 4),
        new BaseLevel(4f, 30, 2, 4),
        new BaseLevel(3f, 30, 2, 4),
        new BaseLevel(4f, 30, 3, 4),
        new BaseLevel(3f, 30, 3, 4),
        new BaseLevel(2f, 40, 3, 4),
        new BaseLevel(4f, 40, 3, 5),
        new BaseLevel(3f, 40, 3, 5),
        new BaseLevel(2f, 40, 3, 5),
        new BaseLevel(4f, 45, 3, 6),
        new BaseLevel(3f, 45, 3, 6),
        new BaseLevel(3f, 45, 3, 6),
        new BaseLevel(3f, 45, 4, 7),
        new BaseLevel(2f, 45, 4, 7),
        new BaseLevel(2f, 45, 4, 7),
        new BaseLevel(1f, 55, 4, 7),
        new BaseLevel(2f, 55, 4, 7),
        new BaseLevel(2f, 55, 4, 8),
        new BaseLevel(1f, 55, 4, 8),
        new BaseLevel(1.5f, 55, 4, 8),
        new BaseLevel(1f, 55, 4, 9),
        new BaseLevel(1f, 70, 4, 9),
        new BaseLevel(1f, 100, 4, 10)
    };
}