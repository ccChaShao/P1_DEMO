using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// 角色移动系统
/// </summary>
partial struct CharacterMoveSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (character, move, transform, entity) in SystemAPI.Query<RefRO<ICharacterData>,RefRW<IMoveData>, RefRW<LocalTransform>>().WithEntityAccess())
        {
            if (move.ValueRW.moveValue.x != 0 || move.ValueRW.moveValue.y != 0)
            {
                // 位移更新
                float3 moveV3 = new float3(
                    move.ValueRW.moveValue.x,
                    move.ValueRW.moveValue.y,
                    0
                ) * character.ValueRO.speed;
                transform.ValueRW.Position += moveV3;
            
                // 朝向更新
                switch (character.ValueRO.characterType)
                {
                    case CharacterType.Enemy :
                    case CharacterType.Player :
                        if (move.ValueRW.moveValue.x != 0)
                        {
                            int val = move.ValueRW.moveValue.x < 0 ? 0 : 180;
                            transform.ValueRW.Rotation = Quaternion.Euler(0, val, 0);
                        }
                        break;
                }
            }
        }
    }
}
