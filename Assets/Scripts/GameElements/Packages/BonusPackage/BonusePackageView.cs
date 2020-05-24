public abstract class BonusePackageView : BasePackage
{
    public override void Activate()
    {
        PackageActive(true);
    }

    public override void Deactivation()
    {
        transform.position = RandomStartPosition();
        PackageActive(false);
    }
}