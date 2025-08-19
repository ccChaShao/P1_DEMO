using Unity.Burst;
using Unity.Entities;

partial struct InitializationSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        // 确保移动计算在行为计算之后执行
        World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<FishSchoolSystem>();
        World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<PositionUpdateSystem>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
