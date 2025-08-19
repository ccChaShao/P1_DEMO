using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class FishGizmosSystem : SystemBase
{
    protected override void OnUpdate()
    {
        // Entities.WithAll<IFishTag>().ForEach((Entity entity) =>
        //     {
        //         LocalTransform transform = EntityManager.GetComponentData<LocalTransform>(entity);
        //         IFishMovementData moveData = EntityManager.GetComponentData<IFishMovementData>(entity);
        //         IFishData fishData = EntityManager.GetComponentData<IFishData>(entity);
        //         // 绘制感知半径
        //         Gizmos.color = Color.blue;
        //         Gizmos.DrawWireSphere(transform.Position, fishData.perceptionRadius);
        //         // 绘制速度方向
        //         Gizmos.color = Color.green;
        //         Gizmos.DrawLine(transform.Position, transform.Position + new float3(moveData.velocity, 0));
        //         Debug.Log("charsiew : [FishGizmosSystem] : -------------------------");
        //     }
        // ).WithoutBurst().Run();

    }
}
