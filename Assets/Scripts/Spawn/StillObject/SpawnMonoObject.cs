public class SpawnMonoObject : SpawnStillObject
{
    public override void Init()
    {
        SpawnObject<BaseGameElement>(_gameElementPref);
    }
}