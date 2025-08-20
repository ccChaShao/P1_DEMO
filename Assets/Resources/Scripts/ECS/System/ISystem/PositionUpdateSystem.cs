using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[BurstCompile]
public partial struct PositionUpdateSystem : ISystem {
    
    [BurstCompile]
    public void OnUpdate(ref SystemState state) {
        float deltaTime = SystemAPI.Time.DeltaTime;
        
        var job = new PositionUpdateJob { DeltaTime = deltaTime };
        job.ScheduleParallel();
    }

    [BurstCompile]
    partial struct PositionUpdateJob : IJobEntity {
        
        public float DeltaTime;
        void Execute(ref LocalTransform transform, in IFishMovementData movement, in IFishTag fishTag) {
            // 应用速度向量更新位置
            float2 newPosition = transform.Position.xy + movement.velocity * DeltaTime;
            transform.Position = new float3(newPosition, 0);

            // // 根据速度方向更新旋转角度
            // float angle = math.atan2(movement.velocity.y, movement.velocity.x);
            // transform.Rotation = quaternion.RotateZ(angle);
            
            // 边界处理（假设屏幕范围：x: [-50,50], y: [-30,30]）
            // float2 pos = newPosition;
            // if (math.abs(pos.x) > 100f) pos.x = -math.sign(pos.x) * 100f;
            // if (math.abs(pos.y) > 50f) pos.y = -math.sign(pos.y) * 50f;
            // transform.Position = new float3(pos, 0);
        }
    }
}