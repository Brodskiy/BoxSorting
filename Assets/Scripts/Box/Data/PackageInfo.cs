using UnityEngine;
public abstract class PackageInfo : MonoBehaviour
{
    public abstract bool WasActive { get;  set; }
    public abstract bool IsCanCaught { get; set; }
}