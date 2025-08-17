using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

/// <summary>
/// 用于处理输入变化
/// </summary>
public partial struct PlayerInputSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        float delatTime = SystemAPI.Time.DeltaTime;
        
        foreach (var (tag,character,input, transform) in SystemAPI.Query<
                     RefRO<IMainPlayerTagData>,
                     RefRO<ICharacterData>,
                     RefRW<IPlayerInputData>,
                     RefRW<LocalTransform>
                 >())
        {
            float3 diff = new float3(
                input.ValueRO.inputValue.x,
                input.ValueRO.inputValue.y,
                0
                ) * character.ValueRO.moveSpeed * delatTime;
            transform.ValueRW.Position += diff;
            
            // 朝向更新
            if (input.ValueRO.inputValue.x != 0)
            {
                int val = input.ValueRO.inputValue.x < 0 ? 0 : 180;          // 左侧为正方向
                transform.ValueRW.Rotation = Quaternion.Euler(0, val, 0);
            }
        }
    }
}
