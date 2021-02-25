using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class TransformSpeedSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities
            .ForEach((ref Rotation rotation, ref Translation translation, in TransformSpeed transformSpeed) =>
            {
                translation.Value += transformSpeed.Speed * deltaTime;

                rotation.Value = math.mul(
                math.normalize(rotation.Value),
                    quaternion.Euler(transformSpeed.RotationSpeed * deltaTime));
            })
            .ScheduleParallel();
    }
}
