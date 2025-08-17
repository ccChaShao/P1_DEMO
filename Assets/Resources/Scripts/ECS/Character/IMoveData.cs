using Unity.Entities;
using Unity.Mathematics;

public struct IMoveData : IComponentData, IEnableableComponent
{
    public float2 moveValue;
}
