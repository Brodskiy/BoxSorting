public interface ILiveLoader : IInitializationSystem
{
    void SaveData();
    LiveData LiveDataInfo { get; set; }
}