using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

partial struct FishClearerSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<IFishSchool>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);

        foreach (var (clearData, clearEntity) in SystemAPI.Query<RefRO<IFishClearData>>().WithEntityAccess())
        {
            // 销毁所有fish
            foreach (var (tag, fishEntity) in SystemAPI.Query<RefRO<IFishTag>>().WithEntityAccess())
            {
                ecb.DestroyEntity(fishEntity);
            }
            ecb.DestroyEntity(clearEntity);
        }
        
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
