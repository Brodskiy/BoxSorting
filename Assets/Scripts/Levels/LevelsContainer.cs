using System.Collections.Generic;
using UnityEngine;

public class LevelsContainer : MonoBehaviour, ILevelContain
{
    public List<LevelModelBase> Levels { get; } = new List<LevelModelBase>()
    {
        new BaseLevel(5, 15000, 2, 4),
        new BaseLevel(4.5f, 15000, 2, 4),
        new BaseLevel(4f, 15, 2, 4),
        new BaseLevel(3.5f, 15, 2, 4),
        new BaseLevel(3f, 15, 2, 4),
        new BaseLevel(4.5f, 5, 3, 4),
        new BaseLevel(4f, 5, 3, 4),
        new BaseLevel(3.5f, 5, 3, 4),
        new BaseLevel(3f, 5, 3, 4),
        new BaseLevel(4.5f, 15, 3, 5),
        new BaseLevel(4f, 15, 3, 5),
        new BaseLevel(3.5f, 15, 3, 5),
        new BaseLevel(3f, 5, 3, 5),
        new BaseLevel(4f, 15, 4, 5),
        new BaseLevel(3.5f, 15, 4, 5),
        new BaseLevel(3.5f, 15, 4, 5),
        new BaseLevel(3.5f, 15, 4, 5),
        new BaseLevel(3.5f, 15, 4, 5),
        new BaseLevel(3.5f, 15, 4, 5),
        new BaseLevel(3.5f, 15, 4, 5),
        new BaseLevel(3.5f, 15, 4, 5),
        new BaseLevel(3.5f, 15, 4, 5),
        new BaseLevel(3.5f, 15, 4, 5),
        new BaseLevel(3.5f, 15, 4, 5),
        new BaseLevel(3.5f, 15, 4, 5),
        new BaseLevel(3.5f, 15, 4, 5),
        new BaseLevel(3.5f, 5, 4, 5)
    };
}