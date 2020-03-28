using System;
using System.Collections.Generic;
using UnityEngine;

public class ChangColor
{
    public List<Color> ListColors { get; private set; }

    public Color RandomColor { get; private set; }

    public ChangColor( int numberOfColor)
    {
        AddColorsToList();
        SetRandomColor(numberOfColor);
    }

    private void AddColorsToList()
    {
        ListColors = new List<Color>();
        ListColors.Add(Color.red);
        ListColors.Add(Color.blue);
        ListColors.Add(Color.green);
        ListColors.Add(Color.cyan);
        ListColors.Add(Color.black);
    }

    private void SetRandomColor(int numberOfColor)
    {
        System.Random random = new System.Random(Guid.NewGuid().GetHashCode());
        RandomColor = ListColors[random.Next(0, numberOfColor)];
    }
}