using System.Collections.Generic;
using UnityEngine;

public class LevelsContainer : MonoBehaviour, ILevelContain
{
    public List<LevelModelBase> Levels { get; } = new List<LevelModelBase>()
    {
        new BaseLevel(5f, 30, 2, 3, false, false),
        new BaseLevel(4.9f , 30, 2, 4, false, false),
        new BaseLevel(4.8f, 35, 3, 4.2f, false, false),
        new BaseLevel(4.7f, 35, 3, 4.4f, false, false),
        new BaseLevel(4.6f, 40, 3, 4.6f, false, false),
        new BaseLevel(4.5f, 40, 3, 4.8f, false, false),
        new BaseLevel(4f, 45, 3, 5, true, true),
        new BaseLevel(3.9f, 45, 3, 5.2f, true, true),
        new BaseLevel(3.8f, 50, 3, 5.4f, true, true),
        new BaseLevel(3.7f, 50, 3, 5.6f, true, true),
        new BaseLevel(3.6f, 55, 3, 5.8f, true, true),
        new BaseLevel(3.5f, 55, 4, 6, true, true),
        new BaseLevel(3.4f, 60, 4, 6.2f, true, true),
        new BaseLevel(3.3f, 60, 4, 6.4f, true, false),
        new BaseLevel(3.2f, 65, 4, 6.6f, true, false),
        new BaseLevel(3.1f, 65, 4, 6.8f, true, false),
        new BaseLevel(3f, 70, 4, 7, true, false),
        new BaseLevel(2.8f, 70, 4, 7.2f, true, false),
        new BaseLevel(2.6f, 85, 4, 7.4f, true, false),
        new BaseLevel(2.4f, 85, 4, 7.6f, true, true),
        new BaseLevel(2.2f, 90, 4, 7.8f, true, true),
        new BaseLevel(2f, 90, 5, 8, true, true),
        new BaseLevel(1.9f, 95, 5, 8.2f, true, true),
        new BaseLevel(1.8f, 95, 5, 8.4f, true, true),
        new BaseLevel(1.7f, 100, 5, 8.6f, true, true),
        new BaseLevel(1.5f, 110, 5, 8.8f, true, true),
        new BaseLevel(1f, 120, 5, 9.5f, true, true)
    };
}