using System.Collections.Generic;
using UnityEngine;

public class LevelsContainer : MonoBehaviour, ILevelContain
{
    public List<LevelModel> Levels { get; } = new List<LevelModel>()
    {
        new BaseLevel(5, 30, 2, 4),
        new BaseLevel(4.5f, 30, 2, 4),
        new BaseLevel(4f, 30, 2, 4),
        new BaseLevel(3.5f, 30, 2, 4),
        new BaseLevel(3f, 30, 2, 4),
        new BaseLevel(4.5f, 30, 3, 4),
        new BaseLevel(4f, 30, 3, 4),
        new BaseLevel(3.5f, 30, 3, 4),
        new BaseLevel(3f, 30, 3, 4),
        new BaseLevel(4.5f, 30, 3, 5),
        new BaseLevel(4f, 30, 3, 5),
        new BaseLevel(3.5f, 30, 3, 5),
        new BaseLevel(3f, 30, 3, 5),
        new BaseLevel(4f, 30, 4, 5),
        new BaseLevel(3.5f, 30, 4, 5)
    };
}