using UnityEngine;

public class BoxInfo : PackageInfo
{
    public override bool WasActive { get; set; }
    public override bool IsCanCaught { get; set; }
    public Color BoxColor { get; set; }
    public bool WasCaught { get; set; }
}