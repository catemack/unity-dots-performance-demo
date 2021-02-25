using Unity.Entities;
using Unity.Mathematics;

public class SpawnerSystem : SystemBase
{
    BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;

    protected override void OnCreate()
    {
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();

        var intTime = (uint)System.DateTime.Now.Ticks;
        var rng = new Random(intTime);


        Entities
            .ForEach((Entity entity, int entityInQueryIndex, ref Spawner spawner) =>
            {
                if (spawner.Count >= spawner.MaxCount)
                {
                    commandBuffer.DestroyEntity(entityInQueryIndex, entity);
                    return;
                }

                spawner.Count++;

                var instance = commandBuffer.Instantiate(entityInQueryIndex, spawner.Prefab);
                commandBuffer.AddComponent(entityInQueryIndex, instance, new TransformSpeed
                {
                    Speed = rng.NextFloat3(new float3(-2, -2, -2), new float3(2, 2, 2)),
                    RotationSpeed = rng.NextFloat3(new float3(0, 0, -2), new float3(0, 0, 2))
                });
            })
            .ScheduleParallel();

        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
}
