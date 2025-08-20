using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct FishSchoolSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<IFishSchool>();
    }
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        int entityCount = SystemAPI.QueryBuilder().WithAll<IFishTag>().Build().CalculateEntityCount();
        
        IFishSchool fishSchool = SystemAPI.GetSingleton<IFishSchool>();

        float3 leaderPosition = float3.zero;
        foreach (var (character, move, transform, entity) in SystemAPI
                     .Query<RefRO<ICharacterData>, RefRW<IMoveData>, RefRW<LocalTransform>>().WithEntityAccess())
        {
            leaderPosition = transform.ValueRO.Position;
        }

        // 获取所有鱼的位置和速度
        NativeArray<float3> positions = new NativeArray<float3>(entityCount, Allocator.TempJob);
        NativeArray<float2> velocities = new NativeArray<float2>(entityCount, Allocator.TempJob);

        FishBehaviorJob job = new FishBehaviorJob()
        {
            leaderPosition = leaderPosition.xy,
            deltaTime = deltaTime,
            positions = positions,
            velocities = velocities,
            leaderWeight = fishSchool.leaderWeight,
            separationWeight = fishSchool.separationWeight,
            alignmentWeight = fishSchool.alignmentWeight,
            cohesionWeight = fishSchool.cohesionWeight
        };
        job.ScheduleParallel();
        
        // 等待所有相关 Job 完成
        state.Dependency.Complete(); // 或 jobHandle.Complete()
        
        // 清理
        positions.Dispose();
        velocities.Dispose();
    }
    
    [BurstCompile]
    public partial struct FishBehaviorJob : IJobEntity
    {
        public float deltaTime;
        public float leaderWeight;
        public float2 leaderPosition;
        [ReadOnly] public NativeArray<float3> positions;
        [ReadOnly] public NativeArray<float2> velocities;
        
        // 三大规则：分离规则，对齐规则，凝聚规则；
        public float separationWeight, alignmentWeight, cohesionWeight;
        
        void Execute(ref IFishMovementData movementData, in IFishData fishData, in LocalTransform transform)
        {
            
            float2 currentPos = transform.Position.xy;
            
            float2 separation = float2.zero;            // 分离规则
            float2 alignment = float2.zero;             // 对齐规则
            float2 cohesion = float2.zero;              // 凝聚规则
            
            int neighborCount = 0;
            
            //  邻居检测
            // TODO 后续可以做算法空间优化
             for (int i = 0; i < positions.Length; i++)
             {
                 float2 neighborPos = positions[i].xy;
                 float distance = math.distance(currentPos, neighborPos);

                 if (distance > 0 && distance < fishData.perceptionRadius)
                 {
                     // 分离规则（统计周围驱散方向）
                     if (distance < fishData.perceptionRadius)
                     {
                         separation += (currentPos - neighborPos) / distance;
                     }
                     
                     // 对齐规则（统计群体运动方向）
                     alignment += velocities[i];
                     
                     // 凝聚规则（统计群体中心位置）
                     cohesion += neighborPos;
                     
                     neighborCount++;
                 }
             }
            
             // 计算行为合力
             if (neighborCount > 0)
             {
                 separation /= neighborCount;
                 alignment = (alignment / neighborCount) - movementData.velocity;
                 cohesion = math.normalize((cohesion / neighborCount) - currentPos);
             }
             // 计算向量合力
             float2 acceleration = separation * separationWeight + 
                                   alignment * alignmentWeight + 
                                   cohesion * cohesionWeight;
             
             float2 leaderDir = leaderPosition - currentPos;
             acceleration += math.normalize(leaderDir) * leaderWeight;
            
             // 更新速度
             movementData.velocity += acceleration * deltaTime;
             movementData.velocity = math.normalize(movementData.velocity) * fishData.speed;
        }
    }
}
