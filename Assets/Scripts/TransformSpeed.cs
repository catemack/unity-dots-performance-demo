using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct TransformSpeed : IComponentData
{
    public float3 RotationSpeed;
    public float3 Speed;
}
