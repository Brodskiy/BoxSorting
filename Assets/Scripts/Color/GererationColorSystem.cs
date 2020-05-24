using System;
using System.Collections.Generic;
using UnityEngine;

public class GererationColorSystem
{
    public List<Color> ListColors { get; private set; }

    public Color RandomColor { get; private set; }

    public GererationColorSystem( int numberOfColor)
    {
        AddColorsToList();
        SetRandomColor(numberOfColor);
    }

    private void AddColorsToList()
    {
        ListColors = new List<Color>();
        ListColors.Add(new Color(1, 0.329f, 0.329f));//red
        ListColors.Add(new Color(0.42f, 0.71f, 1f));//blue
        ListColors.Add(new Color(0.27f, 0.46f, 0.43f));//green
        ListColors.Add(Color.cyan);//cyan
        ListColors.Add(Color.black);//black
    }

    private void SetRandomColor(int numberOfColor)
    {
        System.Random random = new System.Random(Guid.NewGuid().GetHashCode());
        RandomColor = ListColors[random.Next(0, numberOfColor)];
    }
}