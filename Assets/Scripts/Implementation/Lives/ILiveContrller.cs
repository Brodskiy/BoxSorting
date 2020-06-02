public interface ILiveContrller : IInitializationSystem
{
    void LiveAdd(int value);
    void LiveIsLost(int value);
}