using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

[BurstCompile]
partial struct FishSpawnerSystem : ISystem
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
        
        IFishSchool fishSchool = SystemAPI.GetSingleton<IFishSchool>();
        Entity fishPrefab = fishSchool.prefab;
        
        foreach (var (spawner, entity) in SystemAPI.Query<RefRO<IFishSpawnerData>>().WithEntityAccess())
        {
            // 单例数据更新
            fishSchool.cohesionWeight = spawner.ValueRO.cohesionWeight;
            fishSchool.alignmentWeight = spawner.ValueRO.alignmentWeight;
            fishSchool.separationWeight = spawner.ValueRO.separationWeight;
            
            // 创建
            var entities = new NativeArray<Entity>(spawner.ValueRO.spawnerCount, Allocator.Temp);
            state.EntityManager.Instantiate(fishPrefab, entities);
            
            // 位置更新
            for (int i = 0; i < entities.Length; i++) {
                 var position = new float3(Random.Range(-200, 200), Random.Range(-100, 100), 0);
                 SystemAPI.SetComponent(entities[i], new LocalTransform {
                     Position = position,
                     Rotation = quaternion.identity,
                     Scale = 1
                 });
            }
            
            // 记录操作销毁指令
            ecb.DestroyEntity(entity);          
        }
        
        // 执行所有操作指令
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
        
    }
}
