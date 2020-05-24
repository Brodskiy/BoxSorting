public class SpawnMonoObject : SpawnStillObject
{
    public override void Initialization()
    {
        SpawnObject<BaseGameElement>(_gameElementPref);
    }
}