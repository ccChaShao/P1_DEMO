using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

// [BurstCompile]
// partial struct FishSpawnerSystem : ISystem
// {
//     [BurstCompile]
//     public void OnCreate(ref SystemState state)
//     {
//         state.RequireForUpdate<IFishSchool>();
//     }
//
//     [BurstCompile]
//     public void OnUpdate(ref SystemState state)
//     {
//         IFishSchool prefabSchool = SystemAPI.GetSingleton<IFishSchool>();
//         Entity fishPrefab = prefabSchool.prefab;
//         
//         foreach (var (spawner, entity) in SystemAPI.Query<RefRO<IFishSpawnerData>>().WithEntityAccess())
//         {
//             // 创建
//             var entities = new NativeArray<Entity>(spawner.ValueRO.spawnerCount, Allocator.Temp);
//             state.EntityManager.Instantiate(fishPrefab, entities);
//             
//             // 位置更新
//             for (int i = 0; i < spawner.ValueRO.spawnerCount; i++)
//             {
//                 var position = new float3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
//                 SystemAPI.SetComponent(entities[i], new LocalTransform() {
//                     Position = position,
//                     Rotation = quaternion.identity,
//                     Scale = 1
//                 });
//             }
//             
//             // 销毁指令
//             state.EntityManager.DestroyEntity(entity);
//
//             Debug.Log("charsiew : [OnUpdate] : -------------------- 收到指令。");
//         }
//     }
//
//     [BurstCompile]
//     public void OnDestroy(ref SystemState state)
//     {
//         
//     }
// }

public partial class FishSpawnerSystem : SystemBase {
    
    protected override void OnStartRunning() {
         IFishSchool prefabSchool = SystemAPI.GetSingleton<IFishSchool>();
         Entity fishPrefab = prefabSchool.prefab;
         
        var entities = new NativeArray<Entity>(100, Allocator.Temp);
        
        EntityManager.Instantiate(fishPrefab, entities);
        
        for (int i = 0; i < entities.Length; i++) {
            var position = new float3(Random.Range(-100, 100), Random.Range(-50, 50), 0);
            SystemAPI.SetComponent(entities[i], new LocalTransform {
                Position = position,
                Rotation = quaternion.identity,
                Scale = 1
            });
        }
        
        entities.Dispose();
    }

    protected override void OnUpdate()
    {
        
    }
}
