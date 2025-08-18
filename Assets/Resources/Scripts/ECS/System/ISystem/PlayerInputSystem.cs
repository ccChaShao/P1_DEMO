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

        foreach (var (tag, character, input, transform, entity) in SystemAPI.Query<
                     RefRO<IPlayer1TagData>,
                     RefRO<ICharacterData>,
                     RefRW<IPlayerInputData>,
                     RefRW<LocalTransform>
                 >().WithEntityAccess())
        {
            // 位移组件数据更新
            IMoveData moveData = new()
            {
                moveValue = input.ValueRO.inputValue * character.ValueRO.speed * delatTime
            };
            state.EntityManager.SetComponentData(entity, moveData);
        }
    }
}
