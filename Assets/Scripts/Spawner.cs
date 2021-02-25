using Unity.Entities;

public struct Spawner : IComponentData
{
    public Entity Prefab;
    public int Count;
    public int MaxCount;
}
